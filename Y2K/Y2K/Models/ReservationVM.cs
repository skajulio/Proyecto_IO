using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Y2K.Resources;

namespace Y2K.Models
{
    public class ReservationVM
    {

        public Reservation Reservation { get; set; }
        public List<City> City { get; set; }
        public string Mensaje { get; set; }
        public Weather Weather { get; set; }
        public ReservationVM()
        {
            using (var db = new Y2kContext())
            {
                this.City = db.City.ToList();
            }
        }
        public void GetWeather(int id)
        {
            using (Y2kContext context = new Y2kContext())
            {
                var city = context.City.Find(id);
                this.Weather = Resource.GetWeather(city.IdExternal);
            }
            GetMensaje();
        }
        public void GetMensaje()
        {
            if (Weather.cod >= 200 && Weather.cod < 300)
            {
                this.Mensaje = "Procura llevar tu paraguas";
            }
            if (Weather.cod >= 300 && Weather.cod < 400)
            {
                this.Mensaje = "Procura llevar tu paraguas";
            }
            if (Weather.cod >= 400 && Weather.cod < 500)
            {
                this.Mensaje = "Procura llevar tu paraguas";
            }
            if (Weather.cod >= 500 && Weather.cod < 600)
            {
                this.Mensaje = "Procura llevar tu paraguas";
            }
            if (Weather.cod >= 600 && Weather.cod < 700)
            {
                this.Mensaje = "Maneja con cuidado y abrígate bien";
            }
            if (Weather.cod >= 700 && Weather.cod < 800)
            {
                this.Mensaje = "Maneja con cuidao";
            }
            if (Weather.cod == 800)
            {
                this.Mensaje = "Te recomendamos usar bloqueador";
            }
            if (Weather.cod > 800)
            {
                this.Mensaje = "Será un día agradable";
            }
        }
    }
}