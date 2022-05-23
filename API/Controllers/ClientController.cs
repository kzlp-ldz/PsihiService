using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // GET: api/<ClientController>
        [HttpGet]
        public IEnumerable<Problems> Get()
        {
            return DataManag.GetProblems();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Problems> Get(int id)
        {
            var result = DataManag.GetProblem(id);
            if (result == null)
                return NotFound();

            return result;
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Create(Problems problems)
        {
            DataManag.AddProblem(problems);
            return Content("ADDED");
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Problems problems)
        {
            var result = DataManag.GetProblem(id);
            if (result == null)
                return NotFound();

            DataManag.UpdateProblems(id, problems);

            return Content("UPDATED");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = DataManag.GetProblem(id);
            if (result == null)
                return NotFound();

            DataManag.RemoveProblem(id);
            return Content("DELETED");
        }
    }
}
