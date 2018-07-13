using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Y2K.Models;
using Y2K.TransferObject;

namespace Y2K.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();


        }
    }
}