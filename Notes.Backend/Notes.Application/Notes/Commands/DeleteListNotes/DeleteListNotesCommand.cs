using System;
using System.Collections.Generic;
using MediatR;

namespace Notes.Application.Notes.Commands.DeleteListNotes
{
    public class DeleteListNotesCommand : IRequest
    {
        public Guid CreatorId { get; set; }
        public ICollection<Guid> ListId { get; set;  }
    }
}
