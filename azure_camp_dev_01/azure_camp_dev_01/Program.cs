using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.StorageClient
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Queue;

using Newtonsoft.Json;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace azure_camp_dev_01
{

    public class CBATSMessageEntity : TableEntity
    {
        public CBATSMessageEntity(string pkey, string rkey)
        {
            this.PartitionKey = pkey;
            this.RowKey = rkey;
        }
        public string MemberID { get; set; }
        public string jobID { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }

    }

    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            //host.RunAndBlock();           

            //DB에 데이터 저장 예제
            using (SqlConnection connection = new SqlConnection("Data Source = (local); Initial Catalog = pubs; Integrated Security = True; MultipleActiveResultSets = True"))
            {
                using (SqlCommand command = new SqlCommand("insert into azurecamptable(idx, value) values(1, 'test')", connection))
                {
                    connection.Open();
                    using (SqlDataReader dreader = command.ExecuteReader())
                    {
                        while (dreader.Read())
                        {
                            //result = dreader[0].ToString();
                        }
                        dreader.Close();
                    }
                    connection.Close();

                    return;
                }
            }
        }
        
        
    }
}
