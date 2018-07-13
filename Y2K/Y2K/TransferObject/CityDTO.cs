using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Y2K.TransferObject
{
    public class CityDTO
    {
        public int Id{ get; set; }
        public int IdExternal { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}