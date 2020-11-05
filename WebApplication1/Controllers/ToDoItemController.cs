using ConsoleApp1.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private IRepository _repository;
        public ToDoItemController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> QueryAsync()
        {
            var list = await _repository.QueryAsync();
            return Ok(list);
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetAsync(
            [Required] long id)
        {
            //update
            var gotten = await _repository.GetAsync(id);
            return Ok(gotten);
        }

        [HttpPut]//put
        public async Task<ActionResult<ToDoItem>> UpsertAsync(
            [Required] ToDoItem model)
        {
             await _repository.UpsertAsync( model);
            var item = await _repository.GetAsync(model.Id);
            if (item == null)
                return new ObjectResult(500) { };
            return Ok(item);
        }
    }
}
