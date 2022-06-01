using BasicWebServer.Server;
using BasicWebServer.Server.Routing;
using Sms.Data.Common;
using SMS.Contracts;
using SMS.Data;
using SMS.Services;
using System.Threading.Tasks;

namespace SMS
{

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<SMSDbContext>()
                .Add<IRepository, Repository>()
                .Add<IValidationService, ValidationService>()
                .Add<IProductService, ProductService>()
                .Add<ICartService, CartService>();


            await server.Start();
        }
    }
}
