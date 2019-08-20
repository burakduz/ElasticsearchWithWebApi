using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticsearchLog.Dao;
using ElasticsearchLog.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet()]
        public ActionResult<IEnumerable<LogVariableDTO>> Get()
        {
            GetData_ElasticsearchDAO getData = new GetData_ElasticsearchDAO("http://192.168.0.107:9200/");
            List<LogVariableDTO> list= getData.GetLastDatasWithFromAndSize(0, 10, "logforexample");
            return list;
        }

        // GET api/values/5
        [HttpGet("{forQuery}")]
        public ActionResult<IEnumerable<LogVariableDTO>> Get( [FromBody]LogVariableDTO forQuery)
        {
            GetData_ElasticsearchDAO getData = new GetData_ElasticsearchDAO("http://192.168.0.107:9200/");
            List<LogVariableDTO> list = getData.getDataWithQuery(forQuery, 0, 10, "logforexample");
            return list;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] LogVariableDTO value)
        {
            SendData_ElasticsearchDAO sendData = new SendData_ElasticsearchDAO("http://192.168.0.107:9200/");

            return sendData.insertToElasticsearch(value, "logforexample");
        }


    }
}
