using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Models.GraphQL;
using GraphQL_Demo.Queries;
using GraphQL_Demo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GraphQL_Demo.Controllers
{
    public class ConventionalAPIController : System.Web.Http.ApiController
    {
        readonly DataService blogService;

        public ConventionalAPIController()
        {
            this.blogService = new DataService();
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            return new ObjectResult(blogService.GetAllAuthors());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDataById(int id)
        {
            return new ObjectResult(blogService.GetAuthorById(id));
        }

        [HttpGet("{id}/posts")]
        public IActionResult GetPostsDetailsByAuthor(int id)
        {
            return new ObjectResult(blogService.GetPostsByAuthor(id));
        }

        [HttpGet("{id}/socials")]
        public IActionResult GetSocialSitesDetailsByAuthor(int id)
        {
            return new ObjectResult(blogService.GetSNsByAuthor(id));
        }
    }
}
