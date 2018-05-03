using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Models;
using OpenWeatherMap;

namespace ConsoleApp1
{
    public class Weather2Base
    {
        private WeatherNotesContext notesContext = new WeatherNotesContext();
        private 

        public Weather2Base()
        {

        }

        public string[] GetLastNotes(int count)
        {

        }

        public void Dispose()
        {
            notesContext.Dispose();
        }
    }
}
