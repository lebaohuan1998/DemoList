using DemoList.Configurations;
using DemoList.Data;
using DemoList.IRepository;
using DemoList.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("sqlConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          /*builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com");*/
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddAutoMapper(typeof(Mapperinitilizer));

builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

builder.Services.AddControllers().AddNewtonsoftJson(op => 
op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.File("log.txt");
});
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
