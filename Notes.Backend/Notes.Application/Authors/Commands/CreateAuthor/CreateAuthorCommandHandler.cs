using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandle : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateAuthorCommandHandle(INotesDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author creator = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Photo = request.Photo
            };

            await _dbContext.Сreators.AddAsync(creator, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return creator.Id;
        }
    }
}
