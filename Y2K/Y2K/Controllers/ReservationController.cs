using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y2K.Models;
using Y2K.Resources;

namespace Y2K.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            //Resource.GetWeather(2172797);
            Resource.GetCity();
            ReservationVM reservationVM = new ReservationVM();
            return View(reservationVM);
        }

        [HttpPost]
        public ActionResult Index(ReservationVM NewReservation)
        {
            using (var db = new Y2kContext())
            {
                db.Reservacion.Add(NewReservation.Reservation);

                db.SaveChanges();
                return RedirectToAction("Resultado", new { Id = NewReservation.Reservation.Id});
            }
        }

        [HttpGet]
        public ActionResult Resultado(int Id)
        {

            ReservationVM reservation = new ReservationVM();
            using (var db = new Y2kContext())
            {
                reservation.Reservation = db.Reservacion.Include("City").FirstOrDefault(s => s.Id == Id);

            }
            reservation.GetWeather(reservation.Reservation.City.Id);
            return View(reservation);
        }
    }
}