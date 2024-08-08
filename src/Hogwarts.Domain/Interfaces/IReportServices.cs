using Hogwarts.Domain.Entities.Primitives;

namespace Hogwarts.Domain.Interfaces;

public interface IReportServices<T> where T : EntityBase
{
    Task<MemoryStream> GetMemoryStreamReport(List<T> records);
}