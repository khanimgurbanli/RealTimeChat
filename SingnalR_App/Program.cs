using SingnalR_App.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500") 
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); 
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowLocalhost");

app.MapHub<MainHub>("/mainhub");
app.Run();
