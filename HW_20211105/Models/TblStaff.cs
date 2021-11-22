using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HW_20211105.Models
{
    public partial class TblStaff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Department { get; set; }
        public string Title { get; set; }
        public int? Age { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
