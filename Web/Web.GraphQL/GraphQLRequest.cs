
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GraphQL;
using GraphQL.SystemTextJson;

namespace Web.GraphQL
{
    public class GraphQLRequest
    {
        public string Query { get; set; }

        [JsonConverter(typeof(ObjectDictionaryConverter))]
        public Dictionary<string, object> Variables { get; set; }


        //public Newtonsoft.Json.Linq.JObject Variables { get; set; }

        //public Inputs Variables { get; set; }

    }
}
