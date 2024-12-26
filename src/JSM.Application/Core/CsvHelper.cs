using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System.Globalization;
using System.Text;
using JSM.Application.Core.Interfaces;

namespace JSM.Application.Core
{
    public class CsvHelper : ICsvHelper
    {
        public List<T> ImportCsv<T, TCsvMapper>(string file) where T : class where TCsvMapper : ClassMap<T>
        {
            try
            {
                using var memoryStream = new MemoryStream(Convert.FromBase64String(file));
                using var reader = new StreamReader(memoryStream, Encoding.Latin1);

                var csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture);
                using var csv = new CsvReader(reader, csvConfiguration);

                csv.Context.RegisterClassMap<TCsvMapper>();
                var newListCsv = csv.GetRecords<T>().ToList();

                return newListCsv;
            }
            catch (TypeConverterException ex)
            {
                throw new InvalidCastException($"It's not possible to convert the text '{ex.Text}', column '{ex.MemberMapData.Member!.Name}', line '{ex.Context!.Parser!.Row}'");
            }
        }
    }
}
