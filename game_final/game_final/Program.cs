using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace game_final
{
    class Program
    {
        static void Main(string[] args)
        {
            //테이블 생성
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;BlobEndpoint=https://<저장소이름>.blob.core.windows.net/;TableEndpoint=https://<저장소이름>.table.core.windows.net/;QueueEndpoint=https://<저장소이름>.queue.core.windows.net/;FileEndpoint=https://<저장소이름>.file.core.windows.net/");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("game01");
            table.CreateIfNotExists();
            Console.ReadLine();
        }
    }
}
