using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Author creator = await _dbContext.Сreators.FindAsync(new object[] { request.CreatorId }, cancellationToken)
                         ?? throw new NotFoundException(nameof(Author), request.CreatorId);
            
            Note note = new Note
            {
                CreatorId = request.CreatorId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                Сreator = creator,
                CreationDate = DateTime.Now
            };


            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
