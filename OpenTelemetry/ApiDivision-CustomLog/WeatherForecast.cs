namespace ApiDivision
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        /// C'est une donn�e sensible ... ne pas la logger !!! <summary>
        public string? FrileuName { get; set; }
    }
}
