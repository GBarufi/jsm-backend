using CsvHelper.Configuration;

namespace JSM.Application.Core.Interfaces
{
    public interface ICsvHelper
    {
        List<T> ImportCsv<T, CsvMapper>(byte[] file) where T : class where CsvMapper : ClassMap<T>;
    }
}
