using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dto
{
    public class LogVariableDTO
    {
        public string id { get; set; }

        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userLevel { get; set; }



        public DateTime logDate { get; set; }


        public string logDescription { get; set; }
        public string logType { get; set; }
    }
}
