using ElasticsearchLog.Dao.Interfaces;
using ElasticsearchLog.Dto;
using ElasticsearchLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao
{
    public class GetData_ElasticsearchDAO : ElasticsearchDAO, getElasticsearchDataWithQueryAndSizeInterface,getElasticsearchDataWithSizeInterface
    {
        public GetData_ElasticsearchDAO(string ip) : base(ip) { }

        public List<LogVariableDTO> getDataWithQuery(LogVariableDTO forQuery, int from, int size, string indexName)
        {
            List<LogVariableDTO> logs = new List<LogVariableDTO>();
            ElasticsearchQueryControl control = new ElasticsearchQueryControl();
            var filters = control.Filters(forQuery);
            var searchResponse =
               elasticClient.Search<LogVariable>(x => x
               .Index(indexName)
               .From(from)
               .Size(size)
               .Query(q => q
                 .Bool(bq => bq.Filter(filters))
                   ));
            foreach (var hit in searchResponse.Hits)
            {
                LogVariableDTO logDTO = new LogVariableDTO();//Buralar ELden Geçirilecek
                logDTO.id = hit.Source.id;
                logDTO.logDate = hit.Source.logDate;
                logDTO.logDescription = hit.Source.logDescription;
                logDTO.logType = hit.Source.userLevel = hit.Source.userLevel;
                logDTO.userName = hit.Source.userName;
                logDTO.userSurname = hit.Source.userSurname;

                logs.Add(logDTO);
            }
            return logs;
        }

        public List<LogVariableDTO> GetLastDatasWithFromAndSize(int from, int size, string indexName)
        {
            List<LogVariableDTO> listLogVariable = new List<LogVariableDTO>();

            var response = this.elasticClient.Search<LogVariable>(s => s
                .Index(indexName)
                .From(from)
                .Size(size)
                .Query(q => q.MatchAll()));
            foreach (var hit in response.Hits)
            {
                LogVariableDTO logDTO = new LogVariableDTO();
                logDTO.id = hit.Source.id;
                logDTO.logDate = hit.Source.logDate;
                logDTO.logDescription = hit.Source.logDescription;
                logDTO.logType = hit.Source.userLevel = hit.Source.userLevel;
                logDTO.userName = hit.Source.userName;
                logDTO.userSurname = hit.Source.userSurname;

                listLogVariable.Add(logDTO);
            }
            return listLogVariable;
        }
    }
}
