using PayrollApp.Database;
using PayrollApp.Repository;
using PayrollApp.Service;

var builder = WebApplication.CreateBuilder(args);
const string policyName = "CorsPolicy";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Allow CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
//Adding DI
builder.Services.AddTransient<IDataAccess, DatabaseUtilities>();

builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRouting();
    app.UseCors(policyName);
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
