using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCars.Models
{
    public class Car
    {
        //property
        public int Id { get; set; }

        [Required(ErrorMessage = "REQUIRED!")]
        [Range(1980, 2017)]
        public int YearOfProduction { get; set; }

        [Required(ErrorMessage = "REQUIRED!")]
        public string Engine { get; set; }

        [Required(ErrorMessage = "REQUIRED!")]
        public string Color { get; set; }

        //foreign key
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
