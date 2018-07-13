using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Y2K.Models;
using AutoMapper;
using Y2K.TransferObject;

namespace Y2K.Controllers
{
    public class CityController : ApiController
    {
        private Y2kContext context;

        public CityController()
        {//Inicisliza el contexto
            context = new Y2kContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var cities = context.City.ToList();
            if (cities == null)
            {
                return NotFound();
            }
            var cityDto = Mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cities);
            return Ok(cityDto);
        }

        [HttpGet]
        public IHttpActionResult Get(int? Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = context.City.Find(Id);

            if (city == null)
            {
                return NotFound();
            }
            var CityDTO = Mapper.Map<City, CityDTO>(city);
            return Ok(CityDTO);
        }
        [HttpPost]
        public IHttpActionResult Create(CityDTO cityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = Mapper.Map<CityDTO, City>(cityDTO);
            var cityDto = context.City.Add(city);
            context.SaveChanges();
            var dto = Mapper.Map<City, CityDTO>(cityDto);
            return Created(new Uri(Request.RequestUri.ToString()), dto);
        }
        [HttpPut]
        public IHttpActionResult Update(int id, CityDTO cityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var city = context.City.Find(id);

            if (city == null)
                return NotFound();

            Mapper.Map(cityDTO, city);
            context.SaveChanges();
            return Ok(cityDTO);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = context.City.Find(id);

            if (post == null)
                return NotFound();

            context.City.Remove(post);
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
