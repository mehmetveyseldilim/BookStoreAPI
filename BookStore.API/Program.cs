using BookStore.API.Extensions;
using BookStore.API.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<HandleValidationFailureFilterAttribute>();
// Add services to the container.
builder.Services.ConfigureValidators();
builder.Host.ConfigureSerilog(builder.Configuration);
builder.Services.AddPostgresDbContext(builder.Configuration);
builder.Services.AddAutoMapperService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwaggerBookStoreAPI", Version = "v1" });
});


var app = builder.Build();

app.UseGlobalExceptionHandlerMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Seed(app.Environment);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
