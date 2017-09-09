using Nancy;

namespace Collectively.Services.Blockchain.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("", args => "Welcome to the Collectively.Services.Blockchain API!");
        }
    }
}