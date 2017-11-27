using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TobeyExamination.ViewModel
{
    public class HomeViewModel
    {
    }
    public class AddEmployeeViewModel
    {
        [Required]
        [Display(Name = "中文名字")]
        [RegularExpression(@"[\u4e00-\u9fa5]{1,10}", ErrorMessage = "須輸入中文且最多10個字")]
        public string Name { get; set; }

        [Display(Name = "英文名字")]
        [RegularExpression(@"[a-zA-Z]{0,30}", ErrorMessage = "須輸入英文最最多30個字")]
        public string EnName { get; set; }
    }
    public class UpdEmployeeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "中文名字")]
        [RegularExpression(@"[\u4e00-\u9fa5]{1,10}", ErrorMessage = "須輸入中文且最多10個字")]
        public string Name { get; set; }

        [Display(Name = "英文名字")]
        [RegularExpression(@"[a-zA-Z]{0,30}", ErrorMessage = "須輸入英文最最多30個字")]
        public string EnName { get; set; }
    }
}