using System;
using MediatR;

namespace Notes.Application.Notes.Queries.GetNote
{
    public class GetNoteQuery : IRequest<ViewModelGetNote> 
    {
        public Guid CreatorId { get; set;}
        public Guid Id { get; set; }
    }
}
