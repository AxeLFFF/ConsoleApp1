using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Models;
using OpenWeatherMap;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp1
{
    public class Weather2Base
    {
        private WeatherNotesContext NotesContext;
        private OpenWeatherMapClient WeatherMapClient;
        private string CityName;

        public Weather2Base(string cityName)
        {
            this.NotesContext = new WeatherNotesContext();
            this.WeatherMapClient = new OpenWeatherMapClient();
            this.CityName = cityName;
        }

        public async Task UpdateWeather()
        {
            var currentWeather = await this.WeatherMapClient.CurrentWeather.
                GetByName(this.CityName, MetricSystem.Metric, OpenWeatherMapLanguage.RU);
            WeatherNote note = new WeatherNote()
            {
                Temperature = (int)currentWeather.Temperature.Value,
                WindSpeed = (int)currentWeather.Wind.Speed.Value,
                Moment = DateTime.Now
            };
            this.NoteToDB(note);
        }

        private void NoteToDB(WeatherNote weatherNote)
        {
            this.NotesContext.WeatherNotes.Add(weatherNote);
            this.NotesContext.SaveChanges();
        }

        public string[] GetLastNotes(int count)
        {
            IEnumerable<WeatherNote> notes = this.NotesContext.WeatherNotes.OrderByDescending(n => n.Id).Take(count);
            List<string> noteList = new List<string>();
            foreach(var n in notes)
            {
                noteList.Add($"{n.Moment.Value.ToShortDateString()} " +
                    $"{n.Moment.Value.ToShortTimeString()} " +
                    $"temp={n.Temperature.ToString()} " +
                    $"wind={n.WindSpeed.ToString()}");
            }
            return noteList.ToArray();
        }

        public void Dispose()
        {
            NotesContext.Dispose();
        }
    }
}
