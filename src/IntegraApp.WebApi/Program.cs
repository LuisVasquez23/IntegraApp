using IntegraApp.Application;
using IntegraApp.Persistence;
using IntegraApp.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
        .AddWebApi()
        .AddApplication()
        .AddPersistence(builder.Configuration)
        .AddHttpContextAccessor();

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowOrigin",
           builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           });
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
