using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Y2K.Models
{
    public class City
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int IdExternal { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}