using System;

namespace Notes.Domain
{
    public class Note
    {
        public Author Сreator { get; set; }
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
