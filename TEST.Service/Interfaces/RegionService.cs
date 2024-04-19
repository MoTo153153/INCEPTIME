using System.Collections.Generic;
using System.Linq;
using TEST.Model;
using TEST.Model.ViewModels;
using TEST.Service.Implements;

namespace TEST.Service.Interfaces
{
    public class RegionService : IRegionService
    {
        public List<RegionViewModel> GetData()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.Region.Select(x => new RegionViewModel
                {
                    RegionID = x.RegionID,
                    RegionDescription = x.RegionDescription
                }).OrderBy(x => x.RegionID).ToList();
            }
        }

        public RegionViewModel GetDataById(int id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                return db.Region.Where(x => x.RegionID == id).Select(x => new RegionViewModel
                {
                    RegionID = x.RegionID,
                    RegionDescription = x.RegionDescription
                }).FirstOrDefault();
            }
        }

        public bool Update(RegionViewModel model)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var data = db.Region.Where(x => x.RegionID == model.RegionID).FirstOrDefault();

                if (data == null)
                    return false;

                data.RegionDescription = model.RegionDescription;
                db.SaveChanges();

                return true;
            }
        }

        public bool Add(RegionViewModel model)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var maxObj = db.Region.OrderByDescending(x => x.RegionID).FirstOrDefault();
                var regionID = maxObj == null ? 0 : (maxObj.RegionID + 1);

                db.Region.Add(new Region
                {
                    RegionID = regionID,
                    RegionDescription = model.RegionDescription
                });
                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                var data = db.Region.Where(x => x.RegionID == id).FirstOrDefault();

                if (data == null)
                    return false;

                db.Region.Remove(data);
                db.SaveChanges();

                return true;
            }
        }
    }
}
