using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

namespace queue_porcess
{
    class Program
    {
        static void Main(string[] args)
        {
            // 큐 생성처리
            //createQueue();
            //insertQueue();
            deQueueGetMessage();
        }

        static public void createQueue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue");
            queue.CreateIfNotExists();
        }

        static public void insertQueue()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            CloudQueueMessage message = new CloudQueueMessage("게임세미나");
            queue.AddMessage(message);

            //while (true)
            //{
            //    CloudQueueMessage message = new CloudQueueMessage("큐에 작업할 내역 추가");
            //    queue.AddMessage(message);
            //    System.Threading.Thread.Sleep(1000);
            //    Console.WriteLine("큐삽입 완료");
            //}
        }

        static public void deQueueGetMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=<저장소이름>;AccountKey=<저장소키>;");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue");
            CloudQueueMessage retrievedMessage = queue.GetMessage();

            Console.WriteLine(retrievedMessage.AsString);

            queue.DeleteMessage(retrievedMessage);

            Console.WriteLine("큐삭제 완료");
            Console.ReadLine();
        }
    }
}
