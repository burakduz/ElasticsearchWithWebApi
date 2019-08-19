using ElasticsearchLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao.Interfaces
{
    interface insertToElasticsearchInterface
    {
        string insertToElasticsearch(LogVariableDTO data, string indexName);
    }
}
