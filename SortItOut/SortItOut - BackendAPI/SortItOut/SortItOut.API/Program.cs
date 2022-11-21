using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Identity.Web;
using SortItOut.Core.Interface;
using SortItOut.Core.Service;
using SortItOut.Core.Service.Auth;
using SortItOut.DataAccess;
using SortItOut.DataAccess.Csc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISortItOutDataAccess>
(
    service => new SortItOutDataAccess(builder.Configuration)
);

builder.Services.AddScoped<ISortItOutService>
(
    service => new SortItOutService(service.GetRequiredService<ISortItOutDataAccess>())
);

builder.Services.AddCors(options => options.AddPolicy("allowAny", o => o.AllowAnyOrigin()));
builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization();


var app = builder.Build();


app.UseCors();
app.UseAuthentication();

app.MapGet("/secure", [EnableCors("allowAny")] (HttpContext context) =>
{
    AuthHelper.UserHasAnyAcceptedScopes(context, new string[] { "access_as_user" });
    return "hello from secure";
}).RequireAuthorization();


app.MapGet("/insecure", [EnableCors("allowAny")] () =>
{
    return "hello from insecure";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
