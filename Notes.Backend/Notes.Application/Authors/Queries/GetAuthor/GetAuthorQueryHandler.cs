using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;
using AutoMapper;

namespace Notes.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, ViewModelGetAuthor>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorQueryHandler(INotesDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ViewModelGetAuthor> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            Author creator = await _dbContext.Сreators.FindAsync(new object[] { request.Id }, cancellationToken)
                         ?? throw new NotFoundException(nameof(Author), request.Id);

            return _mapper.Map<ViewModelGetAuthor>(creator);
        }
    }
}
