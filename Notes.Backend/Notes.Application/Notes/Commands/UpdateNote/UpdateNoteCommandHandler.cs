using System;
using Notes.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using System.Linq;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public UpdateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext; 
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = await _dbContext.Notes.Where(note => note.CreatorId == request.CreatorId)
                     .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken)
                     ?? throw new NotFoundException(nameof(Note), request.Id);

            note.Details = request.Details;
            note.Title = request.Title;
            note.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
