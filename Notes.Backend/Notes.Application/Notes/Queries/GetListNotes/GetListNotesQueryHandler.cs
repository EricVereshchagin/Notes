using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Queries.GetListNotes
{
    public class GetListNotesQueryHandler : IRequestHandler<GetListNotesQuery, ViewModelGetListNotes>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetListNotesQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ViewModelGetListNotes> Handle(GetListNotesQuery request, CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                .Where(note => note.CreatorId == request.CreatorId)
                .ProjectTo<ViewModelGetListNote>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ViewModelGetListNotes { Notes = notesQuery };
        }
    }
}
