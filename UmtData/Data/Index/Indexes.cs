using System.Collections.Generic;
using System.ComponentModel;
using PropertyChanged;
using UmtData.Data.Index.Base;

namespace UmtData.Data.Index
{
    [ImplementPropertyChanged]
    public class Indexes
    {
        public string Name { get; set; } = string.Empty;

        public List<CoilStatus> CoilStatuses { get; set; } = new List<CoilStatus>();

        public List<IndexGroup<InputStatus>> InputStatusGroups { get; set; } = new List<IndexGroup<InputStatus>>();

        public List<IndexGroup<InputRegister>> InputRegisterGroups { get; set; } = new List<IndexGroup<InputRegister>>();

        public List<IndexGroup<HoldRegister>> HoldRegisterGroups { get; set; } = new List<IndexGroup<HoldRegister>>();

        public BindingList<CustomType.CustomType> CustomTypes { get; set; } = new BindingList<CustomType.CustomType>();

        public List<SpecialFunctionIndex> SpecialFunctions { get; set; } = new List<SpecialFunctionIndex>();

        public void InsertDefaultCustomType()
        {
            CustomTypes.Insert(0, new CustomType.CustomType()
            {
                Id = 0,
                Name = "(не выбран)"
            });
        }
    }
}