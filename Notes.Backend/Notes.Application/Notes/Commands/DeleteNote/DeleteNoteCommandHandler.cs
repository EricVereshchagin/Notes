using System.Threading.Tasks;
using System.Threading;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = await _dbContext.Notes.Where(note => note.CreatorId == request.CreatorId)
                 .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken)
                 ?? throw new NotFoundException(nameof(Note), request.Id); 

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
