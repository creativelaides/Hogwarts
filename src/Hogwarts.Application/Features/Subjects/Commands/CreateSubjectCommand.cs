using Hogwarts.Domain.Entities;
using Hogwarts.Infrastructure;
using MediatR;

namespace Hogwarts.Application.Features.Subjects.Commands;

public class CreateSubjectCommand
{
    public record CreateSubjectCommandRequest(CreateSubjectRequest CreateSubjectRequest) : IRequest<Guid>;

    internal class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommandRequest, Guid>
    {
        private readonly HogwartsDbContext _context;

        public CreateSubjectCommandHandler(HogwartsDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(
            CreateSubjectCommandRequest request, 
            CancellationToken cancellationToken)
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = request.CreateSubjectRequest.Name,
                Description = request.CreateSubjectRequest.Description,
                ProfessorId = request.CreateSubjectRequest.ProfessorId,
            };

            _context.Add(subject);

            await _context.SaveChangesAsync(cancellationToken);

            return subject.Id;
        }
    }
}
