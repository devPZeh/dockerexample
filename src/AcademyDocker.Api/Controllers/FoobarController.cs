using System.Collections.Generic;
using System.Threading.Tasks;
using AcademyDocker.DataContract.Data;
using Microsoft.AspNetCore.Mvc;

namespace AcademyDocker.Api.Controllers
{
    [Produces("application/json")]
    [Route("AcademyDocker/v1/[controller]")]
    public class FoobarController : IwControllerBase
    {
        [HttpGet]
        //[RequiredPermissions("read_list_of_foobar")]
        public ActionResult<IEnumerable<Foobar>> Get()
        {
            return new[]
            {
                new Foobar
                {
                    Foo = "Foo1",
                    Bar = 1
                },
                new Foobar
                {
                    Foo = "Foo2",
                    Bar = 2
                }
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Foobar>> Get(int id)
        {
            var serviceHeaders = await GetServiceHeaders();

            return new Foobar { Foo = "Foo", Bar = 1 };
        }

        [HttpPost]
        public void Post([FromBody] Foobar value)
        {
            Created(Request.Path.Value, new Foobar {Foo = "Foo", Bar = 1});
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Foobar value)
        {
            NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NoContent();
        }
    }
}