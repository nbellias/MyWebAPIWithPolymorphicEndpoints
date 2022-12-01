using Microsoft.AspNetCore.Mvc;
using MyWebAPIWithPolymorphicEndpoints.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPIWithPolymorphicEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        public static List<dynamic> MyList = new List<dynamic>();

        // GET: api/<MyController>
        [HttpGet]
        public IEnumerable<dynamic> Retrieve()
        {
            return MyList;
        }

        // GET api/<MyController>/5
        [HttpGet("{listIndex}")]
        public dynamic Retrieve(int listIndex)
        {
            return MyList[listIndex];
        }

        // GET api/<MyController>/5/6
        [HttpGet("{listIndex}/{id}")]
        public dynamic Retrieve(int listIndex, int id)
        {
            return new
            {
                myid = id + new Random().Next(1, 6),
                mydata = MyList[listIndex]
            };
        }

        // POST api/<MyController>
        [HttpPost]
        public void Create([FromBody] MyRequestObject value)
        {
            MyList.Add(value.Data);
        }

        // PUT api/<MyController>/5
        // PUT uses a lot of bandwidth
        [HttpPut("{listIndex}")]
        public void Update(int listIndex, [FromBody] MyRequestObject value)
        {
            MyList[listIndex] = value.Data;

        }

        // PATCH api/<MyController>/5?message=hello
        // PATCH uses a small amount of bandwidth
        // Use when you want to update only a part of an object
        [HttpPatch("{listIndex}")]
        public void Update(int listIndex, [FromQuery]string message)
        {
            MyList[listIndex] = message;
        }

        // PATCH api/<MyController>/5/234
        // PATCH uses a small amount of bandwidth
        // Use when you want to update only a part of an object
        [HttpPatch("{listIndex}/{aNumber}")]
        public void Update(int listIndex, int aNumber)
        {
            MyList[listIndex] = aNumber;
        }

        // DELETE api/<MyController>/5
        [HttpDelete("{listIndex}")]
        public void Delete(int listIndex)
        {
            MyList.Remove(MyList[listIndex]);
        }
    }
}
