using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReceptionController : Controller
    {
        public static IList<Reception> Reservation = new List<Reception>
        {
            new Reception() {Id=1,Employee_name="Wiktor",Name="karol",Surename="Nowak",Start_of_reservation= (new DateTime(2001,11,11)),End_of_reservation= (new DateTime(2001,11,12)),Description=" sadasdsa",Room="108"},
            new Reception() {Id=2,Employee_name="Karol",Name="karol",Surename="Nowak",Start_of_reservation= (new DateTime(2001,11,11)),End_of_reservation= (new DateTime(2001,11,12)),Description=" sadasdsa",Room="109"}
        };

        // GET: HomeController1
        public ActionResult Index()
        {
            return View(Reservation);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View(Reservation.FirstOrDefault(x => x.Id == id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reception res)
        {
            try
            {
                if (res.Start_of_reservation < res.End_of_reservation)
                {
                    if (res.Start_of_reservation < res.End_of_reservation)
                    {
                        bool Check_if_not_taken = true;
                        foreach (var reservation in Reservation)
                        {
                            if (res.Room == reservation.Room)
                            {
                                if (res.Start_of_reservation >= reservation.Start_of_reservation && res.Start_of_reservation <= reservation.End_of_reservation)
                                {
                                    Check_if_not_taken = false;
                                }
                                if (res.End_of_reservation >= reservation.Start_of_reservation && res.End_of_reservation <= reservation.End_of_reservation)
                                {
                                    Check_if_not_taken = false;
                                }
                                if (res.Start_of_reservation <= reservation.Start_of_reservation && res.End_of_reservation >= reservation.End_of_reservation)
                                {
                                    Check_if_not_taken = false;
                                }
                            }
                        }
                        if (Check_if_not_taken == true)
                        {
                            res.Id = Reservation.Count + 1;
                            Reservation.Add(res);
                        }
                    }

                    
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        { 
            return View(Reservation.FirstOrDefault(x => x.Id == id));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reception res)
        {
            try
            {
                if (res.Start_of_reservation < res.End_of_reservation)
                {
                    bool Check_if_not_taken = true;
                    foreach (var reservation in Reservation)
                    {
                        if (res.Room == reservation.Room && res.Id != reservation.Id)
                        {
                            if(res.Start_of_reservation>=reservation.Start_of_reservation && res.Start_of_reservation <= reservation.End_of_reservation)
                            {
                                Check_if_not_taken=false;
                            }
                            if (res.End_of_reservation >= reservation.Start_of_reservation && res.End_of_reservation <= reservation.End_of_reservation)
                            {
                                Check_if_not_taken = false;
                            }
                            if(res.Start_of_reservation <= reservation.Start_of_reservation && res.End_of_reservation >= reservation.End_of_reservation)
                            {
                                Check_if_not_taken = false;
                            }
                        }
                    }
                    if (Check_if_not_taken == true)
                    {
                        Reception reservation = Reservation.FirstOrDefault(x => x.Id == id);
                        reservation.Employee_name = res.Employee_name;
                        reservation.Name = res.Name;
                        reservation.Surename = res.Surename;
                        reservation.Start_of_reservation = res.Start_of_reservation;
                        reservation.End_of_reservation = res.End_of_reservation;
                        reservation.Description = res.Description;
                        reservation.Room = res.Room;
                    }
                    
                }
                        return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Reservation.FirstOrDefault(x => x.Id == id));
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Reservation.Remove(Reservation.FirstOrDefault(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
