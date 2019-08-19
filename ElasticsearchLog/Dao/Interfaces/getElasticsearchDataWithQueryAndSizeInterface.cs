using ElasticsearchLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao.Interfaces
{
    interface getElasticsearchDataWithQueryAndSizeInterface
    {
        List<LogVariableDTO> getDataWithQuery(LogVariableDTO forQuery, int from,int size, string indexName);

    }
}
