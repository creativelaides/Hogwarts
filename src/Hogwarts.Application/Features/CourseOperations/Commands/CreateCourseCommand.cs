using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using MediatR;

namespace Hogwarts.Application.Features.CourseOperations.Commands;

public class CreateCourseCommand
{
    public record CreateCourseCommandRequest(CreateCourseRequest CreateCourseRequest) : IRequest<Guid>;

    internal class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, Guid>
    {
        private readonly HogwartsDbContext _context;

        public CreateCourseCommandHandler(HogwartsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateCourseCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = request.CreateCourseRequest.Name,
                Description = request.CreateCourseRequest.Description,
                ProfessorId = request.CreateCourseRequest.ProfessorId,
            };

            _context.Add(course);

            await _context.SaveChangesAsync(cancellationToken);

            return course.Id;
        }
    }
}
