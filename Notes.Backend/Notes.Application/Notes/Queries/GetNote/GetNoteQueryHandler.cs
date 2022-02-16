using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;
using System.Linq;

using AutoMapper;

namespace Notes.Application.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, ViewModelGetNote>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ViewModelGetNote> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            Note note = await _dbContext.Notes.Where(note => note.CreatorId == request.CreatorId)
                          .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken)
                          ?? throw new NotFoundException(nameof(Note), request.Id);

            if (note.CreatorId != request.CreatorId)
            {
                throw new NotFoundException(nameof(Author), request.CreatorId);
            };

            return _mapper.Map<ViewModelGetNote>(note);
        }
    }
}
