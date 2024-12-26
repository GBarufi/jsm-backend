using JSM.Application.Commands.Customers.CreateCustomer;
using JSM.WebApi.Configuration;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMediator();
builder.Services.ConfigureInMemoryDatabase(builder.Configuration);

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

var httpResponse = await new HttpClient().GetAsync("https://storage.googleapis.com/juntossomosmais-code-challenge/input-backend.csv");
var responseContent = await httpResponse.Content.ReadAsStringAsync();
var command = new CreateCustomerFromCsvCommand { Content = responseContent };

var mediatorService = app.Services.GetService<IMediator>()!;
await mediatorService.Send(command);

app.Run();
