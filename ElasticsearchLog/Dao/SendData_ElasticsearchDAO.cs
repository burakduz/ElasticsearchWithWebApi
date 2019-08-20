using ElasticsearchLog.Dao.Interfaces;
using ElasticsearchLog.Dto;
using ElasticsearchLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao
{
    public class SendData_ElasticsearchDAO : ElasticsearchDAO,insertToElasticsearchInterface
    {
        public SendData_ElasticsearchDAO(string ip) : base(ip) { }

        public string insertToElasticsearch(LogVariableDTO data, string indexName)
        {

            //var createIndexResponse = elasticClient.Indices.Create(indexName, c => c
            //     .Map<LogVariable>(m => m.AutoMap())
            //    );

            LogVariable log = new LogVariable();
             log = ElasticsearchTranslate.TranslateToLogVariable(data);
            var response = elasticClient.Index(log, i => i
            .Index(indexName));
            return response.DebugInformation.ToString();
        }
    }
}
