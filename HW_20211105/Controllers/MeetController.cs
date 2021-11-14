using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW_20211105.Models;

namespace HW_20211105.Controllers
{
    public class MeetController : Controller
    {
        private readonly HomeWorkContext _context;

        public MeetController(HomeWorkContext context)
        {
            _context = context;
        }

        static List<select> s = new List<select>()
        {
            new select {value =  1,display= "1" },
            new select {value =  2,display= "2" },
            new select {value =  3,display= "3" },
            new select {value =  4,display= "4" },
            new select {value =  5,display= "5" },
            new select {value =  6,display= "6" },
            new select {value =  7,display= "7" },
            new select {value =  8,display= "8" },
            new select {value =  9,display= "9" },
        };

        public IActionResult Index()
        {
            ViewData["select"] = s;

            var room = _context.TblMeetingRoom.ToList();

            ViewBag.Room = room;

            return View();
        }

        [HttpPost]
        //public IActionResult Insert(string Subject,int? RoomId,string StartDateTime,string EndDateTime,int? AttendCount,int? BookedBy)
        public IActionResult Insert(TblMeetingAppointment collection)
        {
            collection.StartDateTime = DateTime.Parse(collection.StartDateTime).ToString("yyyy/MM/dd HH:mm");
            collection.EndDateTime = DateTime.Parse(collection.EndDateTime).ToString("yyyy/MM/dd HH:mm");
            _context.TblMeetingAppointment.Add(collection);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
