using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SensorClient.Options;

namespace SensorClient;

public class SubscriptionController : Controller
{
    private readonly IOptions<ClientConfig> _options;

    public SubscriptionController(IOptions<ClientConfig> options)
    {
        _options = options;
    }
    
    
}