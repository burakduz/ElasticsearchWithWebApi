using ElasticsearchLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao.Interfaces
{
    interface getElasticsearchDataWithSizeInterface
    {
        List<LogVariableDTO> GetLastDatasWithFromAndSize(int from, int size, string indexName);

    }
}
