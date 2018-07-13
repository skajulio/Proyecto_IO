using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Y2K.TransferObject
{
    public class WeatherTDO
    {
        public int Id { get; set; }
        public int IdExternal { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int cod { get; set; }
    }
}