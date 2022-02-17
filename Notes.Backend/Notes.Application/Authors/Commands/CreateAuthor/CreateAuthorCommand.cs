using System;
using MediatR;
using System.Drawing;

namespace Notes.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand: IRequest<Guid>
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
