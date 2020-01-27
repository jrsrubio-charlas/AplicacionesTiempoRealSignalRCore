using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Options;
using SignalRDemo2.CrossCutting.ModelsSettings;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo2.API.Services
{
    public class SendToEventHubService : ISendToEventHubService
    {
        private readonly IOptions<EventHubSettingsModels> _ehConfig;
        private EventHubClient eventHubClient;

        public SendToEventHubService(IOptions<EventHubSettingsModels> ehConfig)
        {
            _ehConfig = ehConfig;
        }

        public async Task SendMessageToEventHub<T>(string ehEntityPath, T model)
        {
            var message = JsonConvert.SerializeObject(model);

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(_ehConfig.Value.EhConnectionString)
            {
                EntityPath = ehEntityPath
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());

            await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
        }
    }
}

