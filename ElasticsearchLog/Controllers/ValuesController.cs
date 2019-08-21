using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElasticsearchLog.Dao;
using ElasticsearchLog.Dao.Interfaces;
using ElasticsearchLog.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{from}/{size}")]     
        public ActionResult<IEnumerable<LogVariableDTO>> Get(int from , int size)
        {
           getElasticsearchDataWithSizeInterface  getData = new GetData_ElasticsearchDAO("http://192.168.0.107:9200/");
            List<LogVariableDTO> list= getData.GetLastDatasWithFromAndSize(from, size, "logforexample");
            return list;
        }

        // GET api/values/5
        [HttpGet("{from}/{size}/{forQuery}")]
        public ActionResult<IEnumerable<LogVariableDTO>> Get(int from,int size, [FromBody]LogVariableDTO forQuery)
        {
            getElasticsearchDataWithQueryAndSizeInterface getData = new GetData_ElasticsearchDAO("http://192.168.0.107:9200/");
            List<LogVariableDTO> list = getData.getDataWithQuery(forQuery, from, size, "logforexample");
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
