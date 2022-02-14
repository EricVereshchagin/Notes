using System;
using System.Collections.Generic;
using System.Drawing;

namespace Notes.Domain
{
    public class Author
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Image Photo { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
