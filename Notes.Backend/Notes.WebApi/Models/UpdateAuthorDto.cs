using AutoMapper;
using Notes.Application.Authors.Commands.UpdateAuthor;
using Notes.Application.Common.Mappings;

namespace Notes.WebApi.Models
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorCommand>
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(creatorCommand => creatorCommand.Name,
                opt => opt.MapFrom(creatorCommand => creatorCommand.Name))
                .ForMember(creatorCommand => creatorCommand.Photo,
                opt => opt.MapFrom(creatorCommand => creatorCommand.Photo));
        }
    }
}
