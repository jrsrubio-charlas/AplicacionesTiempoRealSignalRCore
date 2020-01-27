using System.Threading.Tasks;

namespace SignalRDemo2.API.Services
{
    public interface ISendToEventHubService
    {
        Task SendMessageToEventHub<T>(string ehEntityPath, T model);
    }
}
