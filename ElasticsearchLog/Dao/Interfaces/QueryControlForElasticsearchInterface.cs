using ElasticsearchLog.Dto;
using ElasticsearchLog.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao.Interfaces
{
    interface QueryControlForElasticsearchInterface
    {
         List<Func<QueryContainerDescriptor<LogVariable>, QueryContainer>> Filters(LogVariableDTO forQuery);
    }
}
