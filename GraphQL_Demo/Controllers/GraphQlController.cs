﻿using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Models.GraphQL;
using GraphQL_Demo.Queries;
using GraphQL_Demo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GraphQL_Demo.Controllers
{
    public class GraphQlController : System.Web.Http.ApiController
    {
        readonly BlogService blogService;

        public GraphQlController()
        {
            this.blogService = new BlogService();
        }
       

        public async Task<object> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new AuthorQuery(blogService) };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return string.Empty;
            }
            return result;

        }
    }
}