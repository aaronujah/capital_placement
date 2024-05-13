using Capital_Placement.Configuration;
using Capital_Placement.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<CapitalPlacementContext>(optionsBuilder =>
  optionsBuilder
    .UseCosmos(
      connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
      databaseName: "CapitalPlacementDb",
      cosmosOptionsAction: options =>
      {
          options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
          options.MaxRequestsPerTcpConnection(16);
          options.MaxTcpConnectionsPerEndpoint(32);
      }));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ResolveDependencies();

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
