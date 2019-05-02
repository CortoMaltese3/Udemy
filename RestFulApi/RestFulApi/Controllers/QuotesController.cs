using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFulApi.Models;

namespace RestFulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> _quotes = new List<Quote>()
        {
            new Quote(){ Id = 0, Title = "The Parrot's Theorem", Author = "Denis Guedj", Description= "The Parrot's Theorem is a French novel written by Denis Guedj and published in 1998."  },
            new Quote(){ Id = 1, Title = "The Silmarillion", Author = "Christopher Tolkien", Description= "The Silmarillion is a collection of mythopoeic works by English writer J. R. R. Tolkien"  }
        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }
        
        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            _quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.RemoveAt(id);
        }

    }
}