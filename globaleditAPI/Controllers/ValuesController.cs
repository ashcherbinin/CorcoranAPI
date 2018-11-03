using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorcoranAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CorcoranAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : Controller
    {

        private readonly IPresidentRepository _repository;

        public ValuesController(IPresidentRepository repository)
        {
            _repository = repository;
        }

    
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _repository.getPresidentList("asc"));
        }


    }
}
