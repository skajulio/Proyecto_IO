using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Y2K.Models;
using Y2K.TransferObject;

namespace Y2K.Controllers
{
    public class WeatherController : ApiController
    {
        private Y2kContext context;

        public WeatherController()
        {//Inicisliza el contexto
            context = new Y2kContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var weather = context.Weather.ToList();
            if (weather == null)
            {
                return NotFound();
            }
            var weatherDto = Mapper.Map<IEnumerable<Weather>, IEnumerable<WeatherTDO>>(weather);
            return Ok(weatherDto);
        }

        [HttpGet]
        public IHttpActionResult Get(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var weather = context.Weather.Find(Id);

            if (weather == null)
            {
                return NotFound();
            }
            var CityDTO = Mapper.Map<Weather, WeatherTDO>(weather);
            return Ok(CityDTO);
        }
        [HttpPost]
        public IHttpActionResult Create(WeatherTDO weatherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var weather = Mapper.Map<WeatherTDO, Weather>(weatherDTO);
            var weatherDto = context.Weather.Add(weather);
            context.SaveChanges();
            var dto = Mapper.Map<Weather, WeatherTDO>(weatherDto);
            return Created(new Uri(Request.RequestUri.ToString()), dto);
        }
        [HttpPut]
        public IHttpActionResult Update(int id, WeatherTDO weatherDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var weather = context.City.Find(id);

            if (weather == null)
                return NotFound();

            Mapper.Map(weatherDTO, weather);
            context.SaveChanges();
            return Ok(weatherDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var weather = context.Weather.Find(id);

            if (weather == null)
                return NotFound();

            context.Weather.Remove(weather);
            context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}
