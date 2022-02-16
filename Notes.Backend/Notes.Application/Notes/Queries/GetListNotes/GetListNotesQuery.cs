using System;
using MediatR;

namespace Notes.Application.Notes.Queries.GetListNotes
{
    public class GetListNotesQuery : IRequest<ViewModelGetListNotes>
    {
        public Guid CreatorId { get; set; }

    }
}
