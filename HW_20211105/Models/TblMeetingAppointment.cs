using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HW_20211105.Models
{
    public partial class TblMeetingAppointment
    {
        [Key]
        public int MeetingId { get; set; }
        public string Subject { get; set; }
        public int? RoomId { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public int? AttendCount { get; set; }
        public int? BookedBy { get; set; }
    }
}
