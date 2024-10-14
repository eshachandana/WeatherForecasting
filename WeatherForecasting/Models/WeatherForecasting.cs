using System;

namespace WeatherForecasting.Models
{
    public class WeatherforcastingModel
    {
        public string Name { get; set; }
        public Main Main { get; set; }
        public Sys Sys { get; set; }
        public WeatherComparisonMetrics PercentageDifference { get; set; }

        // Constructor to initialize nested objects
        public WeatherforcastingModel()
        {
           Main = new Main();
           Sys = new Sys();

        }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }

        public float feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
    }

    public class WeatherComparisonMetrics
    {
        public float TempDiffPercent { get; set; }
        public float FeelsLikeDiffPercent { get; set; }
        public float HumidityDiffPercent { get; set; }
        public float PressureDiffPercent { get; set; }
    }
}