using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.ViewModels
{
    public class UploadFileViewModel
    {
        [Required]
        public string FileName { get; set; }
        
        public string UploadedBy { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime UploadedOn { get; set; }
        public IFormFile Files { get; set; }



    }
}
