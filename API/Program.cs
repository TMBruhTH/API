using Repository.Interface;
using Repository.Repository;
using Service.Interface;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthentication();

/*SERVICES*/
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ILogradouroService, LogradouroService>();
/*REPOSITORY*/
builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
