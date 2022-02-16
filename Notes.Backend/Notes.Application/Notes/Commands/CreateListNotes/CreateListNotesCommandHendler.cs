using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Commands.CreateListNotes
{
    public class CreateListNotesCommandHendler : IRequestHandler<CreateListNotesCommand, ICollection<Guid>>
    {
        private readonly INotesDbContext _dbContext;

        public CreateListNotesCommandHendler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<ICollection<Guid>> Handle(CreateListNotesCommand request, CancellationToken cancellationToken)
        {
            Author creator = await _dbContext.Сreators.FindAsync(new object[] { request.CreatorId }, cancellationToken)
                         ?? throw new NotFoundException(nameof(Author), request.CreatorId);

            var listNotes = request.ListNotes.Select(requestNote => new Note
            {
                CreationDate = DateTime.Now,
                Details = requestNote.Details,
                Сreator = creator,
                Title = requestNote.Title,
                CreatorId = creator.Id,
                Id = Guid.NewGuid()
            });

            await _dbContext.Notes.AddRangeAsync(listNotes, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return listNotes.Select(note => note.Id).ToList(); 
        }

    }
}
