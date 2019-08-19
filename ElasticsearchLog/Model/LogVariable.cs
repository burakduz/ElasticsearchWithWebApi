using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Model
{
    [ElasticsearchType(Name = "doc")]
    public class LogVariable
    {
        [Text(Name = "id", Analyzer = "keyword")]
        public string id { get; set; }

        [Text(Name = "user_name", Analyzer = "keyword")]
        public string userName { get; set; }

        [Text(Name = "user_surname", Analyzer = "keyword")]
        public string userSurname { get; set; }

        [Text(Name = "user_level", Analyzer = "keyword")]

        public string userLevel { get; set; }


        [Date(Name = "log_date")]
        public DateTime logDate { get; set; }

        [Text(Name = "log_description", Analyzer = "whitespace")]
        public string logDescription { get; set; }

        [Text(Name = "log_type", Analyzer = "keyword")]
        public string logType { get; set; }
    }
}
