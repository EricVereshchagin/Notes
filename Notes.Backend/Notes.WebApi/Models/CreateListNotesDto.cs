using AutoMapper;
using Notes.Application.Notes.Commands.CreateListNotes;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Common.Mappings;
using System.Collections.Generic;

namespace Notes.WebApi.Models
{
    public class CreateListNotesDto : IMapWith<CreateListNotesCommand>
    {
        public ICollection<CreateNoteCommand> ListNotes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateListNotesDto, CreateListNotesCommand>()
                .ForMember(noteCommand => noteCommand.ListNotes,
                opt => opt.MapFrom(noteDto => noteDto.ListNotes));
        }
    }
}
