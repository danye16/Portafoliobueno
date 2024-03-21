using Amazon.Auth.AccessControlPolicy;
using Portafolio2.Api.Configurations;
using Portafolio2.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddSingleton<InfoPersonalServices>();
builder.Services.AddSingleton<ProyectosServices>();

//para que agarre la api en angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyClient", policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//asegurate se llame antes que UseAuthorization
app.UseCors("AnyClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
