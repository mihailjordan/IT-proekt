using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INS_FInal.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DepAdmin { get; set; }
        //public List<string> workersId { get; set; }

        public Department()
        {

        }
    }
}
