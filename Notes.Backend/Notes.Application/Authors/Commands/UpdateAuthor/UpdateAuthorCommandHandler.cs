using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly INotesDbContext _dbContext;
        public UpdateAuthorCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author creator = await _dbContext.Сreators.FindAsync(new object[] { request.Id }, cancellationToken)
                        ?? throw new NotFoundException(nameof(Author), request.Id);
            
            creator.Name = request.Name;
            creator.Photo = request.Photo;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value; 
        }
    }
}
