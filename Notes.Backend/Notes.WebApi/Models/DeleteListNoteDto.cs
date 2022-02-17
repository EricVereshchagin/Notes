using AutoMapper;
using Notes.Application.Notes.Commands.DeleteListNotes;
using Notes.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Notes.WebApi.Models
{
    public class DeleteListNotesDto : IMapWith<DeleteListNotesCommand>
    {
        public ICollection<Guid> ListId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeleteListNotesDto, DeleteListNotesCommand>()
                .ForMember(noteCommand => noteCommand.ListId,
                opt => opt.MapFrom(noteDto => noteDto.ListId));
        }
    }
}
