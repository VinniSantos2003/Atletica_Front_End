using Atletica_Back_End.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
builder.Services.AddDbContext<ApplicationContext>(options => 
    { options.UseSqlite("Data Source=AtleticaApp.db");
});
/*builder.Services.AddDbContext<ApplicationContext>(options =>{

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConfiguration"));

});*/

var myPolicy = "policy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myPolicy, policy =>
    
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()

    );

});    

var app = builder.Build();

app.UseCors(myPolicy);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
