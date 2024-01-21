using BeSql.Client;
using BeSql.Client.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddBesqlDbContextFactory<OfflineDbContext>();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    // Create db context
    await using var dbContext = await scope.ServiceProvider
        .GetRequiredService<IDbContextFactory<OfflineDbContext>>()
        .CreateDbContextAsync();

    // migrate database
    await dbContext.Database.MigrateAsync();
}

await app.RunAsync();
