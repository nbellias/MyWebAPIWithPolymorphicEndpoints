using Microsoft.AspNetCore.Mvc;
using MyWebAPIWithPolymorphicEndpoints.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPIWithPolymorphicEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        // List of dynamic JSON values of Employees
        private static List<dynamic> MyList = new List<dynamic>()
        {
            new
            {
                id = 1,
                name = "John",
                age = 30,
                salary = 30000
            },
            new
            {
                id = 2,
                name = "Mary",
                age = 25,
                salary = 25000
            },
            new
            {
                id = 3,
                name = "Peter",
                age = 28,
                salary = 28000
            }
        };


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
            try
            {
                return MyList[listIndex];
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
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

        // PUT api/<MyController>/upd/5?message=Hello&myDecimal=2345.567
        // PUT uses a lot of bandwidth
        [HttpPut("upd/{listIndex}")]
        public void Update(int listIndex, [FromQuery] string message, [FromQuery] decimal myDecimal)
        {
            MyList[listIndex] = new
            {
                message = message,
                aDecimal = myDecimal
            };
        }

        // PATCH api/<MyController>/5?message=hello
        // PATCH uses a small amount of bandwidth
        // Use when you want to update only a part of an object
        [HttpPatch("{listIndex}")]
        public void Update(int listIndex, [FromQuery] string message)
        {
            MyList[listIndex] = new
            {
                message = message
            };
        }

        // PATCH api/<MyController>/5/234
        // PATCH uses a small amount of bandwidth
        // Use when you want to update only a part of an object
        [HttpPatch("{listIndex}/{aNumber}")]
        public void Update(int listIndex, decimal aNumber)
        {
            MyList[listIndex] = new
            {
                aNumber = aNumber
            };
        }

        // DELETE api/<MyController>/5
        [HttpDelete("{listIndex}")]
        public void Delete(int listIndex)
        {
            MyList.Remove(MyList[listIndex]);
        }
    }
}
