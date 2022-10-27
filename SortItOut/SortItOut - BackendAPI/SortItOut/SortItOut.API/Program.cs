using SortItOut.Core.Interface;
using SortItOut.Core.Service;
using SortItOut.DataAccess;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(CscDataAccess)
(
    service => new CscDataAccess(builder.Configuration)
);

builder.Services.AddScoped<ISortItOutService>
(
    service => new SortItOutService(service.GetRequiredService<CscDataAccess>())
);

var app = builder.Build();

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
