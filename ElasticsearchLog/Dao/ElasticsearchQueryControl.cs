using ElasticsearchLog.Dao.Interfaces;
using ElasticsearchLog.Dto;
using ElasticsearchLog.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao
{
    public class ElasticsearchQueryControl : QueryControlForElasticsearchInterface
    {
        public List<Func<QueryContainerDescriptor<LogVariable>, QueryContainer>> Filters(LogVariableDTO forQuery)
        {
            var filters = new List<Func<QueryContainerDescriptor<LogVariable>, QueryContainer>>();
            if (forQuery.id != "" && forQuery.id != null)
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.id).Terms(forQuery.id)));
            }
            if (forQuery.logDate != null && forQuery.logDate.ToString() != "1.01.0001 00:00:00")
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.logDate).Terms(forQuery.logDate)));
            }
            if (forQuery.logDescription != "" && forQuery.logDescription != null)
            {
                string[] words = forQuery.logDescription.Split(' ');
                Console.WriteLine(words.Length);
                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i];
                    filters.Add(fq => fq.Wildcard(c => c.Field(f => f.logDescription).Value(word)));
                }

            }
            if (forQuery.logType != "" && forQuery.logType != null)
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.logType).Terms(forQuery.logType)));
            }
            if (forQuery.userLevel != "" && forQuery.userLevel != null)
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.userLevel).Terms(forQuery.userLevel)));
            }

            if (forQuery.userName != "" && forQuery.userName != null)
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.userName).Terms(forQuery.userName)));
            }
            if (forQuery.userSurname != "" && forQuery.userSurname != null)
            {
                filters.Add(fq => fq.Terms(t => t.Field(f => f.userSurname).Terms(forQuery.userSurname)));
            }

            return filters;
        }
    }
}
