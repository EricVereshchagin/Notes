using System;
using System.Collections.Generic;
using MediatR;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.Application.Notes.Commands.CreateListNotes
{
    public class CreateListNotesCommand: IRequest<ICollection<Guid>>
    {
        public Guid CreatorId { get; set; }

        public ICollection<CreateNoteCommand> ListNotes { get; set; }
    }
}
