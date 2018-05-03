using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models
{
    public class WeatherNote
    {
        [Key]
        public int Id { get; set; }

        public int Temperature { get; set; }

        public int WindSpeed { get; set; }
    }
}
