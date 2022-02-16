using System;
using MediatR;
namespace Notes.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<ViewModelGetAuthor>
    {
        public Guid Id { get; set; }
    }
}
