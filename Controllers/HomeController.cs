using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HomeApi.Repo;
using HomeApi.Model;
using HomeApi.Repo.Interface;

namespace HomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IHomeRepo Repo;
        public HomeController(IHomeRepo homeRepo){
            Repo = homeRepo;
        }

        [HttpGet("{id}")]
        public ActionResult<Home> Get(long id)
        {
            return this.Ok(Repo.GetByPropertyId(id));
        }

        [HttpGet]
        public ActionResult<List<Home>> Get(){
            return this.Ok(Repo.GetAllHomes());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Home value)
        {
            try
            {
                Repo.AddHome(value);
                return this.Ok();
            }
            catch(Exception ex){
                return this.BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Repo.DeleteHome(id);
        }
    }
}
