using Nancy;

namespace Collectively.Services.Blockchain.Modules
{
    public class HomeModule : ModuleBase
    {
        public HomeModule() : base(requireAuthentication: false)
        {
            Get("", args => "Welcome to the Collectively.Services.Blockchain API!");
        }
    }
}