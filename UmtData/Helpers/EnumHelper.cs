using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using UmtData.Data.Index;

namespace UmtData.Helpers
{
    public static class EnumHelper
    {
        public static IList<KeyValuePair<T, string>> GenerateValueListFromEnum<T>()
        {
            var typeOfEnum = typeof(T);

            if (!typeOfEnum.IsEnum)
            {
                throw new ArgumentException($"Тип {typeOfEnum} должен быть перечислимым типом.");
            }

            return (from object item in Enum.GetValues(typeOfEnum) select new KeyValuePair<T, string>((T) item, item.ToString())).ToList();
        }

        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute),
                    false);

                return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
            }

            return default(string);
        }

        /// <summary>
        /// Сгенерировать List c парой Значение - Описание для выпадающих списков
        /// </summary>
        /// <typeparam name="T">Enum - перечисление</typeparam>
        /// <returns></returns>
        public static IList<KeyValuePair<T, string>> GenerateListFromEnum<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Тип T должен быть перечислением.");

            return 
                Enum.GetValues(typeof(T))
                    .Cast<T>()
                    .Select(x => new KeyValuePair<T, string>(x, (x as Enum).GetDescription()))
                    .ToList();
        }

        /// <summary>
        /// Сколько байт занимает тип
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetDataTypeSize(this DataType type)
        {
            if (type == DataType.Int32 || type == DataType.Float || type == DataType.Single)
                return 4;
            if (type == DataType.Digital || type == DataType.Int8)
                return 1;
            if (type == DataType.Double)
                return 8;
            //Int16
            return 2;
        }

        public static bool HasFlag(this SpecialFunction value, SpecialFunction flag)
        {
            return (value & flag) != 0;
        }

        public static SpecialFunction RemoveFlag(SpecialFunction value, SpecialFunction flag)
        {
            return Enum.GetValues(typeof(SpecialFunction))
                .Cast<SpecialFunction>()
                .Where(u => u != SpecialFunction.None && u != flag && value.HasFlag(u))
                .Aggregate(SpecialFunction.None, (current, specialFunction) => current | specialFunction);
        }
    }
}

