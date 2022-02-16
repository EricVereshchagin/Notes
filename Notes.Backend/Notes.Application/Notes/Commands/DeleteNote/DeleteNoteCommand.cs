using System;
using MediatR;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid CreatorId { get; set; }
        public Guid Id { get; set; }
    }
}
