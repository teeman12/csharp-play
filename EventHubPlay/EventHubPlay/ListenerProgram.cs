namespace SampleEphReceiver
{
    using System;
    using Microsoft.Azure.EventHubs;
    using Microsoft.Azure.EventHubs.Processor;
    using System.Threading.Tasks;

    public class ListenerProgram
    {
        private const string EventHubConnectionString = "Endpoint=sb://myeventhubplay1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ut/tAOvQvV1BXDkeOk/EoTs9XpGxTQ+UQhpnwgray1M=";
        private const string EventHubName = "eventhub1";
        private const string StorageContainerName = "spehubcontainer";
        private const string StorageAccountName = "msplaygrounddiag";
        private const string StorageAccountKey = "whHs81vAlzTv/8Cex1nRt6cCSHR3XOHja4YVxttCx97BoXgn06Ijk5F6AxIvpnZ2WzpgGgueOJUtuUXHcivHPA==";

        private static readonly string StorageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName, StorageAccountKey);

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                EventHubName,
                PartitionReceiver.DefaultConsumerGroupName,
                EventHubConnectionString,
                StorageConnectionString,
                StorageContainerName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}