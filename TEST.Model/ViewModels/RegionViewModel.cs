using System.ComponentModel.DataAnnotations;

namespace TEST.Model.ViewModels
{
    public class RegionViewModel
    {
        public int RegionID { get; set; }
        [Required(ErrorMessage = "地區描述是必填的")]
        public string RegionDescription { get; set; }
    }
}
