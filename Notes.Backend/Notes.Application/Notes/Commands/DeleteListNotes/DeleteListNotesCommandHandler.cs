using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Commands.DeleteListNotes
{
    public class DeleteListNotesCommandHandler : IRequestHandler<DeleteListNotesCommand, Unit>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteListNotesCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteListNotesCommand request, CancellationToken cancellationToken)
        {
            List<Note> notes = await _dbContext.Notes
                .Where(note => note.CreatorId == request.CreatorId && request.ListId.Contains(note.Id))
                .ToListAsync(cancellationToken)
                ?? throw new NotFoundException(nameof(List<Note>), request.ListId);

            _dbContext.Notes.RemoveRange(notes);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
