using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Model
{
    [ElasticsearchType(RelationName = "_doc")]
    public class LogVariable
    {
        [Text(Name = "id")]
        public string id { get; set; }

        [Text(Name = "user_name")]
        public string userName { get; set; }

        [Text(Name = "user_surname")]
        public string userSurname { get; set; }

        [Text(Name = "user_level")]

        public string userLevel { get; set; }


        [Date(Name = "log_date")]
        public DateTime logDate { get; set; }

        [Text(Name = "log_description")]
        public string logDescription { get; set; }

        [Text(Name = "log_type")]
        public string logType { get; set; }
    }
}
