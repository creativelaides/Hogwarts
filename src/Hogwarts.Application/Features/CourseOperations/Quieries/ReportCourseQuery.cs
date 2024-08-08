using MediatR;
using Microsoft.EntityFrameworkCore;

using Hogwarts.Domain.Entities;
using Hogwarts.Domain.Interfaces;
using Hogwarts.Infrastructure;

namespace Hogwarts.Application.Features.CourseOperations.Queries;

public class ReportCourseQuery
{
    public record ReportCourseQueryRequest : IRequest<MemoryStream>;


    internal class ReportCourseQueryHandler(
        HogwartsDbContext context, 
        IReportServices<Course> reportService, 
        int reportRecords = 10) : IRequestHandler<ReportCourseQueryRequest, MemoryStream>
    {
        private readonly HogwartsDbContext _context = context;
        private readonly IReportServices<Course> _reportService = reportService;

        public async Task<MemoryStream> Handle(
            ReportCourseQueryRequest request,
            CancellationToken cancellationToken)
        {
            var courses = await _context.Courses.Take(reportRecords).Skip(0).ToListAsync(cancellationToken);

            return await _reportService.GetMemoryStreamReport(courses);
        }
    }

}