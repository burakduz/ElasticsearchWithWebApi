using ElasticsearchLog.Dao.Interfaces;
using ElasticsearchLog.Dto;
using ElasticsearchLog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao
{
    public static class ElasticsearchTranslate 
    {
        public static LogVariable TranslateToLogVariable(LogVariableDTO data)
        {
            LogVariable log = new LogVariable();
            log.id = data.id;
            log.logDate = data.logDate;
            log.logDescription = data.logDescription;
            log.logType = data.logType;
            log.userLevel = data.userLevel;
            log.userName = data.userName;
            log.userSurname = data.userSurname;
            return log;
        }
    }
}
