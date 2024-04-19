using System.Web.Mvc;
using TEST.Model.ViewModels;
using TEST.Service.Implements;
using TEST.Service.Interfaces;

namespace TEST.Controllers
{
    public class RegionController : Controller
    {
        private IRegionService _IRegionService;
        public RegionController()
        {
            _IRegionService = new RegionService();
        }

        #region 查詢
        public ViewResult Index()
        {
            var data = _IRegionService.GetData();
            return View(data);
        }
        #endregion

        #region 新增
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _IRegionService.Add(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region 編輯
        public ActionResult Edit(int id)
        {
            RegionViewModel data = _IRegionService.GetDataById(id);
            data.RegionDescription = data.RegionDescription.Trim();

            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(RegionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = _IRegionService.Update(model);

                if (res)
                    return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region 刪除
        public ActionResult Delete(int id)
        {
            var res = _IRegionService.Delete(id);

            if (res)
                return RedirectToAction("Index");
            else
                return HttpNotFound();
        }
        #endregion
    }
}