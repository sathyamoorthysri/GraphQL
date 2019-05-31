using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraphQL;

namespace GraphQL_Demo.Models.GraphQL
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public Inputs Variables { get; set; }
    }
}