using System.Globalization;
using CsvHelper;
using Hogwarts.Domain.Entities.Primitives;
using Hogwarts.Domain.Interfaces;

namespace Hogwarts.Infrastructure.Reports
{
    public class ReportService<T> : IReportServices<T> where T : EntityBase
    {
        public Task<MemoryStream> GetMemoryStreamReport(List<T> records)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(records);
            writer.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);

            return Task.FromResult(memoryStream);
        }
    }
}
