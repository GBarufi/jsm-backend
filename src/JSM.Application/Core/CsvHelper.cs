using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using JSM.Application.Core.Interfaces;
using System.Globalization;

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

        public bool ValidateCsv<T>(byte[] file, string[] expectedFields) where T : class
        {
            var isValid = true;

            try
            {
                using var memoryStream = new MemoryStream(file);
                using var reader = new StreamReader(memoryStream);

                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                using var csv = new CsvReader(reader, csvConfiguration);

                csv.Read();
                csv.ReadHeader();

                if (expectedFields.Length != csv.ColumnCount)
                    isValid = false;

                while (isValid && csv.Read())
                {
                    foreach (var expectedField in expectedFields.Select((propertyName, index) => new { index, propertyName }))
                    {
                        if (csv.GetFieldIndex(expectedField.propertyName) != expectedField.index)
                        {
                            isValid = false;
                            break;
                        }

                        if (string.IsNullOrEmpty(csv.GetField(expectedField.index)))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                return isValid;
            }
            catch
            {
                return false;
            }
        }
    }
}
