using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ElasticLib.QueryModel;
using ElasticLib.Abstraction;
using MyWebApi.Models;
using ElasticLib.Utils.ValidatorUtils.Exceptions;
using System;
using System.Collections.Generic;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private IElasticService elasticService;

        public SearchController(IElasticService elasticService)
        {
            this.elasticService = elasticService;
        }

        [HttpPost]
        [Route("searchNode")]
        public ActionResult<IEnumerable<Node>> NodeSearch([FromBody] string json)
        {
            //TODO
            var nodeQuerySearch = JsonSerializer.Deserialize<NodeQuerySearch>(json);
            try{
                var result = elasticService.Search<Node>(nodeQuerySearch);
                return Ok(result);
            }
            //TODO
            //dummy code
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("searchEdge")]
        public ActionResult<string> EdgeSearch([FromBody] string json)
        {
            //TODO
            var edgeSearchQuery = JsonSerializer.Deserialize<EdgeSearchQuery>(json);
            
            //dummy code:

            //return elastic.nodesearch(edgeSearchQuery);
            return null;
        }
    }
}