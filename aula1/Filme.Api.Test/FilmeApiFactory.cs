using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filme.Helper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Filme.Api.Test
{
    public class FilmeApiFactory : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();
            
            builder.ConfigureServices(services =>{
                services.AddScoped(sp => {
                    return new DbContextOptionsBuilder<FilmeContext>()
                        .UseInMemoryDatabase("Tests", root)
                        .UseApplicationServiceProvider(sp)
                        .Options;
                });
            });

            return base.CreateHost(builder);
        }
    }
}