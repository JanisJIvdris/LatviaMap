using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO.Compression;
using System.Net.Http;
using System.Threading.Tasks;

namespace LatviaMap.Models
{
    public class PlaceRepository
    {
        private readonly string _csvDownloadUrl = "https://data.gov.lv/dati/dataset/0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";
        private readonly string _localZipFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/aw_csv.zip");
        private readonly string _extractedCsvFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/AW_VIETU_CENTROIDI.CSV");

        public PlaceRepository()
        {
            EnsureCsvFile().Wait(); // Ensure async method is called in constructor
        }

        // Ensures that the CSV file is downloaded and extracted
        private async Task EnsureCsvFile()
        {
            if (!File.Exists(_extractedCsvFile))
            {
                await DownloadAndExtractCsv();
            }
        }

        // Downloads the ZIP file and extracts the CSV file
        private async Task DownloadAndExtractCsv()
        {
            try
            {
                // Ensure the directory exists
                string dataDirectory = Path.GetDirectoryName(_localZipFile)!;
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                // Download the ZIP file
                using (var httpClient = new HttpClient())
                {
                    var zipFileBytes = await httpClient.GetByteArrayAsync(_csvDownloadUrl);
                    await File.WriteAllBytesAsync(_localZipFile, zipFileBytes);
                }

                // Extract the ZIP file
                ZipFile.ExtractToDirectory(_localZipFile, dataDirectory, true);

                // Delete the ZIP file after extraction
                if (File.Exists(_localZipFile))
                {
                    File.Delete(_localZipFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the download or extraction process: {ex.Message}");
            }
        }

        // Reads all the places from the CSV file
        public IEnumerable<Place> GetAllPlaces()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                BadDataFound = null,
                MissingFieldFound = null,
                PrepareHeaderForMatch = args => args.Header.Trim('#')
            };

            using (var reader = new StreamReader(_extractedCsvFile))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                return csv.GetRecords<Place>().ToList();
            }
        }

        // Retrieves the extreme places (north, south, east, west)
        public IEnumerable<Place> GetExtremePlaces()
        {
            var places = GetAllPlaces();

            var northernMost = places.OrderByDescending(p => p.Latitude).First();
            var southernMost = places.OrderBy(p => p.Latitude).First();
            var easternMost = places.OrderByDescending(p => p.Longitude).First();
            var westernMost = places.OrderBy(p => p.Longitude).First();

            return new List<Place> { northernMost, southernMost, easternMost, westernMost };
        }
    }
}
