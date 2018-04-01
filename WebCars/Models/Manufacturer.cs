using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCars.Models
{
    public class Manufacturer
    {
        //property
        public int Id { get; set; }

        [Required(ErrorMessage = "REQUIRED!")]
        public string Name { get; set; }

        //list of cars
        public List<Car> Cars { get; set; }
    }
}
