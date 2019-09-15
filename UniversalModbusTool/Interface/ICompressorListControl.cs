using UniversalModbusTool.Controls;

namespace UniversalModbusTool.Interface
{
    public interface ICompressorListControl
    {
        void RemoveCompressor(CompressorItemControl control);
        void EditCompressor(CompressorItemControl control);
    }
}