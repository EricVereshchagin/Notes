using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Notes.Application.Notes.Commands.DeleteListNotes
{
    public class DeleteListNotesCommand : IRequest
    {
        public Guid CreatorId { get; set; }
        public ICollection<Guid> ListId { get; set;  }
    }
}
