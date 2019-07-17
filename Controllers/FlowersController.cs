using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using markoz.Models;
using markoz.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace markoz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly FlowerRepository _repo;
        public FlowersController(FlowerRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Flower>> Get()
        {
            try
            {
                return Ok(_repo.GetALL());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Flower> Get(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Flower> Post([FromBody] Flower value)
        {
            try
            {
                return Ok(_repo.Create(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Flower> Put(int id, [FromBody] Flower value)
        {
            try
            {
                value.Id = id;
                return Ok(_repo.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                return Ok(_repo.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
