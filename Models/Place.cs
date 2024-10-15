using CsvHelper.Configuration.Attributes;
using LatviaMap.Converters;  

namespace LatviaMap.Models
{
    public class Place
    {
        [Name("NOSAUKUMS")]
        public string Name { get; set; } = string.Empty;

        [Name("DD_N")]
        [TypeConverter(typeof(DoubleWithHashConverter))]  
        public double Latitude { get; set; }

        [Name("DD_E")]
        [TypeConverter(typeof(DoubleWithHashConverter))]  
        public double Longitude { get; set; }
    }
}