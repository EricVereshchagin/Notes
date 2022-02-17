using MediatR;
using System.Drawing;
using System;

namespace Notes.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
