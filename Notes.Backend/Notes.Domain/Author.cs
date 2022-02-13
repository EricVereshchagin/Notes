using System;
using System.Drawing;

namespace Notes.Domain
{
    public class Author
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public Image Photo { get; set; }
    }
}
