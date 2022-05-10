using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApplication.Models.DTOs
{    public class ClubDTO
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
