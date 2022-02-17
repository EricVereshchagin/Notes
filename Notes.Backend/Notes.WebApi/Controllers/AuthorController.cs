using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Authors.Commands.CreateAuthor;
using Notes.Application.Authors.Queries.GetAuthor;
using Notes.Application.Authors.Commands.UpdateAuthor;
using Notes.WebApi.Models;

using AutoMapper;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;
        public AuthorController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            var command = new CreateAuthorCommand
            {
                Name = createAuthorCommand.Name,
                Photo = createAuthorCommand.Photo
            };
            UserId = await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            command.Id = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<ViewModelGetAuthor>> Get()
        {
            var query = new GetAuthorQuery
            {
                Id = UserId  
            };

            var vm = await Mediator.Send(query);
            
            return Ok(vm);
        }

    }
}
