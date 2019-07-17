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
    public class BouquetsController : ControllerBase
    {
        private readonly BouquetRepository _repo;
        public BouquetsController(BouquetRepository repo)
        {
            _repo = repo;
        }

        // GET api/Bouquet
        [HttpGet]
        public ActionResult<IEnumerable<Bouquet>> Get()
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

        // GET api/Bouquet/5
        [HttpGet("{id}")]
        public ActionResult<Bouquet> Get(int id)
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

        //GET api/bouquets/:id/flowers
        [HttpGet("{id}/flowers")]
        public ActionResult<IEnumerable<Flower>> GetFlowersByBouquetId(int id)
        {
            try
            {
                return Ok(_repo.GetFlowersByBouquetId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST api/Bouquet
        [HttpPost]
        public ActionResult<Bouquet> Post([FromBody] Bouquet value)
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

        //POST api/bouquets/:id/flowers
        [HttpPost("{id}/flowers")]
        public ActionResult<String> AddFlowerToBouquet(int id, [FromBody] FlowerBouquet flowerBouquet)
        {
            try
            {
                flowerBouquet.BouquetId = id;
                return Ok(_repo.AddFlowerToBouquet(flowerBouquet));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



        // PUT api/Bouquet/5
        [HttpPut("{id}")]
        public ActionResult<Bouquet> Put(int id, [FromBody] Bouquet value)
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

        // DELETE api/Bouquet/5
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
