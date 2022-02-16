using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Drawing;

namespace Notes.Application.Authors.Queries.GetAuthor
{
    public class ViewModelGetAuthor : IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Photo { get; set; }

        public void Mapping(Profile profole)
        {
            profole.CreateMap<Author, ViewModelGetAuthor>()
                .ForMember(authorVm => authorVm.Id,
                opt => opt.MapFrom(author => author.Id))
                .ForMember(authorVm => authorVm.Name,
                opt => opt.MapFrom(author => author.Name))
                .ForMember(authorVm => authorVm.Photo,
                opt => opt.MapFrom(author => author.Photo));
        }
        
    }
}
