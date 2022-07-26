using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    // Enables Identity server
    .AddIdentityServer()
    // Enables Client model
    .AddInMemoryClients(Config.Clients)
    // Enables Api scope model
    .AddInMemoryApiScopes(Config.ApiScopes)
    // Enables Identity resource model
    .AddInMemoryIdentityResources(Config.IdentityResources)
    // Enables Test users model
    .AddTestUsers(Config.TestUsers)
    // Enables signing credential
    .AddDeveloperSigningCredential();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseIdentityServer();
// Adds endpoints for controler actions
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.Run();
