using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WeCount.Data.ViewModels
{
    public class ResumeVM
    {
        [Required(ErrorMessage = "Please choose a Resume")]
        [DataType(DataType.Upload)]
        public IFormFile ResumeFile { get; set; }
    }
}
