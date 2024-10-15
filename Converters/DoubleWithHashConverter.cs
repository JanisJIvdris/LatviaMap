using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace LatviaMap.Converters
{
    public class DoubleWithHashConverter : DoubleConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            // Remove the '#' characters and convert the value to a double
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Trim('#');
            }
            return base.ConvertFromString(text, row, memberMapData);
        }
    }
}