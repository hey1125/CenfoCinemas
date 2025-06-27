using CoreApp;
using DataAccess.CRUD;
using DTOs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public ActionResult Create(User user)    {

            try
            {
                var um = new UserManager();
                um.Create(user);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet]
        [Route("RetriveAll")]
        public ActionResult RetriveAll()
        {
            try
            {
                var um = new UserManager();
                var listResults =um.RetriveAll();
                return Ok(listResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("RetrieveById")]
        public ActionResult RetrieveById([FromQuery] int id)
        {
            try
            {
                var um = new UserManager();
                var result = um.RetrieveById(new User { Id = id });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("RetrieveByEmail")]
        public ActionResult RetrieveByEmail([FromQuery] string email)
        {
            try
            {
                var um = new UserManager();
                var result = um.RetrieveByEmail(new User { Email = email });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("RetrieveByUserCode")]
        public ActionResult RetrieveByUserCode([FromQuery] string code)
        {
            try
            {
                var um = new UserManager();
                var result = um.RetrieveByUserCode(new User { Usercode = code });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [HttpPut("Update")]
        public ActionResult Update([FromBody] User user)
        {
            try
            {
                var um = new UserManager();
                um.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("Delete")]
        public ActionResult Delete([FromBody] User user)
        {
            try
            {
                var um = new UserManager();
                um.Delete(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
