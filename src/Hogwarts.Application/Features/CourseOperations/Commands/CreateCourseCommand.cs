using Hogwarts.Application.Core;
using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using MediatR;

namespace Hogwarts.Application.Features.CourseOperations.Commands;

public class CreateCourseCommand
{
    public record CreateCourseCommandRequest(CreateCourseRequest CreateCourseRequest) : IRequest<Result<Guid>>;

    internal class CreateCourseCommandHandler(HogwartsDbContext context) : IRequestHandler<CreateCourseCommandRequest, Result<Guid>>
    {
        private readonly HogwartsDbContext _context = context;

        public async Task<Result<Guid>> Handle(
            CreateCourseCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = request.CreateCourseRequest.Name,
                Description = request.CreateCourseRequest.Description,
                // ProfessorId = request.CreateCourseRequest.ProfessorId,
            };

            _context.Add(course);

            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            return Result<Guid>.Failure("No se pudo insertar el curso");

            // return result 
            //     ? Result<Guid>.Success(course.Id)
            //     : Result<Guid>.Failure("No se pudo insertar el cupo");
        }
    }
}
