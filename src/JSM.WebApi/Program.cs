using JSM.WebApi.Configurations;
using JSM.WebApi.HostedServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureMediator();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.ConfigureInMemoryDatabase(builder.Configuration);
builder.Services.AddHostedService<ExecuteStartupRequests>();

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
