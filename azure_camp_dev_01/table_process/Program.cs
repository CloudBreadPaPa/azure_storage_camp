using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace table_process
{
    public class CustomerEntity : TableEntity
    {
        public CustomerEntity(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }

        public CustomerEntity() { }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //createTable();
            //insertTable();
            getTable();
                      
        }
        public static void createTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("people");
            table.CreateIfNotExists();
        }

        public static void insertTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("people");
            CustomerEntity customer1 = new CustomerEntity("Harp", Guid.NewGuid().ToString());
            customer1.Email = "Walter@contoso.com";
            customer1.PhoneNumber = "425-555-0101";
            TableOperation insertOperation = TableOperation.Insert(customer1);
            table.Execute(insertOperation);
        }
        public static void getTable()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("people");
            TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Harp"));
            foreach (CustomerEntity entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                    entity.Email, entity.PhoneNumber);
            }
        }
    }
}
