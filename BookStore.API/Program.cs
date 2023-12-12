using BookStore.API.Extensions;
using BookStore.API.Extensions.MiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPostgresDbContext(builder.Configuration);
builder.Services.AddAutoMapperService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ConfigureGlobalExceptionHandler();

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
