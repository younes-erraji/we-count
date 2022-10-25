using System;
using System.ComponentModel.DataAnnotations;

namespace WeCount.Data.ViewModels
{
    public class SearchVM
    {
        [Required]
        [RegularExpression("^[A-Za-z0-9 @.]+$")]
        public string SearchText { get; set; }
    }
}
