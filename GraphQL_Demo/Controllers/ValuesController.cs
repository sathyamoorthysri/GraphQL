using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GraphQL_Demo.Service;

namespace GraphQL_Demo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


        private readonly BlogService blogService;

        public ValuesController()
        {
            this.blogService = new BlogService();
        }

        public List<Models.Author> GetAll()
        {
            return blogService.GetAllAuthors();
        }

        public Models.Author GetAuthorById(int id)
        {
            return blogService.GetAuthorById(id);
        }

        public List<Models.Post> GetPostsByAuthor(int id)
        {
            return blogService.GetPostsByAuthor(id);
        }

        public List<Models.SocialNetwork> GetSocialsByAuthor(int id)
        {
            return blogService.GetSNsByAuthor(id);
        }
    }
}
