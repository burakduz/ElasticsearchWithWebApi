using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchLog.Dao
{
    public class ElasticsearchDAO
    {
        protected ElasticClient elasticClient;

        protected ElasticsearchDAO(string ip)
        {
            this.elasticClient = ElasticsearchDAO.elasticConnection(ip);
        }

        protected static ElasticClient elasticConnection(string ip)//KULLANMIYORUZ İLERDE DÜZELT
        {
            ConnectionSettings connectionSettings;
            ElasticClient elasticClient;
            //StaticConnectionPool connectionPool;

            //   Connection string for Elasticsearch    http://192.168.0.107:9200/
            connectionSettings = new ConnectionSettings(new Uri(ip)); //local PC
            elasticClient = new ElasticClient(connectionSettings);

            //    Multiple node for fail over (cluster addresses)
            //    var nodes = new Uri[]
            //    {
            //new Uri("192.168.0.107:9200"),
            //        //new Uri("Add server 2 address")   //Add cluster addresses here
            //        //new Uri("Add server 3 address")
            //    };

            //    connectionPool = new StaticConnectionPool(nodes);
            //    connectionSettings = new ConnectionSettings(connectionPool);
            elasticClient = new ElasticClient(connectionSettings);

            return elasticClient;

        }
    }
}
