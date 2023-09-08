using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerSale.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CustomerSaleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerSaleContext") ?? throw new InvalidOperationException("Connection string 'CustomerSaleContext' not found.")));

// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//cros policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
        builder =>
        {

            builder

                //.AllowAnyOrigin()                            
                .WithOrigins("http://localhost:1234", "http://localhost:4330", "http://localhost:4200").AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
