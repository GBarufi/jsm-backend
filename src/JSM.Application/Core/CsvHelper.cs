using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;
using JSM.Application.Core.Interfaces;

namespace JSM.Application.Core
{
    public class CsvHelper : ICsvHelper
    {
        public List<T> ImportCsv<T, TCsvMapper>(byte[] file) where T : class where TCsvMapper : ClassMap<T>
        {
            try
            {
                using var memoryStream = new MemoryStream(file);
                using var reader = new StreamReader(memoryStream);

                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                using var csv = new CsvReader(reader, csvConfiguration);

                csv.Context.RegisterClassMap<TCsvMapper>();

                return csv.GetRecords<T>().ToList();
            }
            catch (TypeConverterException ex)
            {
                throw new InvalidCastException($"It's not possible to convert the text '{ex.Text}', column '{ex.MemberMapData.Member!.Name}', line '{ex.Context!.Parser!.Row}'");
            }
        }
    }
}
