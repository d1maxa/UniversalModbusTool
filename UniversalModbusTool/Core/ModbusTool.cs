using System;
using System.Configuration;
using System.IO.Ports;
using System.Threading;
using Modbus.Device;
using Modbus.Extensions.Enron;
using UmtData.Data.Index;
using UmtData.Data.Index.Base;
using UmtData.Data.Settings;
using UmtData.Helpers;

namespace UniversalModbusTool.Core
{
    public static class ModbusTool
    {
        public static decimal Read(BaseIndex index, CompressorSetting compressor)
        {
            return Read(index, compressor, compressor.Address);
        }

        public static decimal Read(BaseIndex index, CompressorSetting compressor, byte slaveId)
        {
            var master = compressor.ComPortSetting?.Master;
            if (master == null)
                return 0;
            var address = index.RealAddress;
            //var slaveId = compressor.Address;

            lock (master)
            {
                if (index is CoilStatus)
                    return master.ReadCoils(slaveId, address, 1)[0] ? 1 : 0;
                if (index is InputStatus)
                    return master.ReadInputs(slaveId, address, 1)[0] ? 1 : 0;

                if (index is BaseRegister)
                {
                    Func<byte, ushort, ushort, ushort[]> func = null;
                    if (index is InputRegister)
                        func = compressor.ComPortSetting.Master.ReadInputRegisters;
                    else if (index is HoldRegister)
                        func = compressor.ComPortSetting.Master.ReadHoldingRegisters;
                    var baseRegister = (BaseRegister) index;

                    switch (index.DataType)
                    {
                        case DataType.Int16:
                            //ushort -> short
                            return ReadRegister<short>(baseRegister, slaveId, func);
                        case DataType.Int32:
                            //ushort -> int
                            return ReadRegister<int>(baseRegister, slaveId, func);
                        case DataType.Int8:
                            //ushort -> sbyte
                            return ReadRegister<sbyte>(baseRegister, slaveId, func);
                        case DataType.Float:
                        case DataType.Single:
                            //ushort -> float
                            return ReadRegister<float>(baseRegister, slaveId, func);
                        case DataType.Double:
                            //ushort -> double
                            return ReadRegister<double>(baseRegister, slaveId, func);
                        case DataType.Digital:
                            //ushort -> bool
                            return ReadRegister<bool>(baseRegister, slaveId, func);
                        default:
                            return Convert.ToDecimal(func(slaveId, address, 1)[0])/
                                   baseRegister.Multiplier;
                    }
                }
            }

            return 0;
        }

        private static decimal ReadRegister<TResult>(BaseRegister index, byte slaveId, Func<byte, ushort, ushort, ushort[]> readFunc) where TResult : struct
        {
            //Как хранится Int8??? в первом байте или во втором ushort?
            //возможно надо будет Buffer.BlockCopy(s, 0, dest, 0, readsize * 2); и брать dest[1]
            var address = index.RealAddress;
            var size = index.DataType.GetDataTypeSize();
            var readSize = (ushort) (size/2);
            var dest = new TResult[1];
            if (size < 2)
            {
                readSize = 1;
                //dest = new T[2];
            }
            //else dest = new T[1];
            var s = readFunc(slaveId, address, readSize);
            Buffer.BlockCopy(s, 0, dest, 0, size);
            return Convert.ToDecimal(dest[0])/index.Multiplier;
        }

        public static void Write(BaseIndex index, CompressorSetting compressor, decimal value)
        {
            var master = compressor.ComPortSetting?.Master;
            if (master == null)
                return;
            var address = index.RealAddress;
            var slaveId = compressor.Address;

            lock (master)
            {
                if (index is CoilStatus)
                {
                    master.WriteSingleCoil(slaveId, address, value == 1);
                    return;
                }
                if (index is InputStatus || index is InputRegister)
                {
                    //read only
                    return;
                }

                if (index is HoldRegister)
                {
                    var holdRegister = (HoldRegister) index;

                    switch (index.DataType)
                    {
                        case DataType.Int16:
                            //ushort <- short
                            WriteRegister<short>(holdRegister, slaveId, master, value);
                            break;
                        case DataType.Int32:
                            //ushort <- int
                            WriteRegister<int>(holdRegister, slaveId, master, value);
                            break;
                        case DataType.Int8:
                            //ushort <- sbyte
                            WriteRegister<sbyte>(holdRegister, slaveId, master, value);
                            break;
                        case DataType.Float:
                        case DataType.Single:
                            //ushort <- float
                            WriteRegister<float>(holdRegister, slaveId, master, value);
                            break;
                        case DataType.Double:
                            //ushort <- double
                            WriteRegister<double>(holdRegister, slaveId, master, value);
                            break;
                        case DataType.Digital:
                            //ushort <- bool
                            WriteRegister<bool>(holdRegister, slaveId, master, value);
                            break;
                        default:
                            master.WriteSingleRegister(slaveId, address, Convert.ToUInt16(value*holdRegister.Multiplier));
                            break;
                    }
                }
            }
        }

        private static void WriteRegister<TResult>(HoldRegister index, byte slaveId, ModbusSerialMaster master, decimal value) where TResult : struct
        {
            //Как хранится Int8??? в первом байте или во втором ushort?
            //возможно надо будет Buffer.BlockCopy(s, 0, dest, 0, readsize * 2); и брать dest[1]
            var address = index.RealAddress;
            //int32 = 4
            var size = index.DataType.GetDataTypeSize();
            //кол-во ushort для записи
            var readSize = (ushort)(size / 2);
            if (size < 2)
            {
                readSize = 1;
            }
            var dest = new ushort[readSize];
            var realValue = new[] {(TResult)Convert.ChangeType(index.Multiplier * value, typeof(TResult))};
            Buffer.BlockCopy(realValue, 0, dest, 0, size);
            if (readSize == 1)
            {
                master.WriteSingleRegister(slaveId, address, dest[0]);
            }
            else
            {
                master.WriteMultipleRegisters(slaveId, address, dest);
            }
        }
    }
}
