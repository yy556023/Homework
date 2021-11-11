using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HW_20211105.Models.Meet
{
    public partial class TblMeetingRoom
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int? RoomSize { get; set; }
    }
}
