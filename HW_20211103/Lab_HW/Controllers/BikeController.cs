using Lab_HW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_HW.Controllers
{
    public class BikeController : Controller
    {

        static List<Bike> bikes = new List<Bike>()
        {
            new Bike{ Id = 1,Lv = "白牌",cc = 150},
            new Bike{ Id = 2,Lv = "黃牌",cc = 350},
            new Bike{ Id = 3,Lv = "紅牌",cc = 650}
        };


        // GET: BikeController
        public ActionResult Index()
        {
            return View(bikes);
        }

        [HttpPost]
        public ActionResult Index(string? id,string? lv,string? cc)
        {
            List<Bike> Data = new List<Bike>();

            if(id != null)
            {
                Data = bikes.Where(x => x.Id == int.Parse(id)).ToList();
            }
            else if (lv != null)
            {
                Data = bikes.Where(x => x.Lv == lv).ToList();
            }
            else if (cc != null)
            {
                Data = bikes.Where(x => x.cc == int.Parse(cc)).ToList();
            }

            return View(Data);
        }

        // GET: BikeController/Details/5
        public ActionResult Details(int id)
        {
            Bike data = bikes.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: BikeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bike collection)
        {
            try
            {
                bikes.Add(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Edit/5
        public ActionResult Edit(int id)
        {
            Bike data = bikes.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: BikeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Bike collection)
        {
            try
            {
                Bike data = bikes.FirstOrDefault(x => x.Id == id);

                if (data == null)
                {
                    return NotFound();
                }

                data.Lv = collection.Lv;
                data.cc = collection.cc;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Delete/5
        public ActionResult Delete(int id)
        {
            Bike data = bikes.FirstOrDefault(x => x.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: BikeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        public ActionResult Delete(Bike collection)
        {
            try
            {
                Bike data = bikes.FirstOrDefault(x => x.Id == collection.Id);

                bikes.Remove(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
