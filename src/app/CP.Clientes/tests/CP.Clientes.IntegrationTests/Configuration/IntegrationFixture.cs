﻿using System.Text.Json;
using CP.Clientes.Infra;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CP.Clientes.IntegrationTests;

public class IntegrationTestFixture : IDisposable
{
    public WebApplicationFactory<Program> Factory { get; }
    public HttpClient Client { get; }
    public CPClientesContext context { get; private set; }

    public IntegrationTestFixture()
    {
        Factory = new WebApplicationFactory<Program>()
         .WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, config) =>
                   {
                       Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
                       context.HostingEnvironment.EnvironmentName = "Testing";
                   });

                builder.ConfigureServices(async services =>
                {
                    // Remove o contexto de banco de dados existente, se houver
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CPClientesContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    services.RemoveAll(typeof(DbContextOptions<CPClientesContext>));
                    services.AddDbContext<CPClientesContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                    var serviceProvider = services.BuildServiceProvider();

                    context = serviceProvider.GetService<CPClientesContext>();
                    context.Database.EnsureCreated();
                    await SeedDatabase();
                });
            });

        Client = Factory.CreateClient();
    }

    public async Task TestarRequisicaoComErro(HttpResponseMessage response, List<string> erros)
    {
        var dados = await response.Content.ReadAsStringAsync();
        var errorDetail = JsonSerializer.Deserialize<ValidationProblemDetails>(dados);

        new ValidationProblemDetails(new Dictionary<string, string[]> {
                { "Mensagens", erros.ToArray() }
            });

        errorDetail.Errors["Mensagens"].Should().BeEquivalentTo(erros);
    }

    public void Dispose()
    {
        Client.Dispose();
        Factory.Dispose();
    }

    private async Task SeedDatabase()
    {
        context.Cliente.Add(new Domain.Entities.Cliente("Teste", "71935710010", "teste@testecadastrado.com"));
        await context.SaveChangesAsync();
    }
}

