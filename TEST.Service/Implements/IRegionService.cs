using System.Collections.Generic;
using TEST.Model.ViewModels;

namespace TEST.Service.Implements
{
    public interface IRegionService
    {
        List<RegionViewModel> GetData();
        RegionViewModel GetDataById(int id);
        bool Update(RegionViewModel model);
        bool Add(RegionViewModel model);
        bool Delete(int id);
    }
}
