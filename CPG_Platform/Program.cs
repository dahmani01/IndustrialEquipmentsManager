using CPG_Platform.Data;
using Microsoft.EntityFrameworkCore;
using CPG_Platform.Controllers;
using CPG_Platform.Models;
using System.Text.Json.Serialization;
using CPG_Platform.Services.UploadFileService;
using CPG_Platform.Services.SectorService;
using CPG_Platform.Services.MachineService;
using CPG_Platform.Services.SeriviceService;
using CPG_Platform.Services.EntretientService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddScoped<IUploadFileService,UploadFileService>();
builder.Services.AddScoped<ISectorService,SectorService>();
builder.Services.AddScoped<IServiceService,ServiceService>();
builder.Services.AddScoped<IMachineService, MachinesService>();
builder.Services.AddScoped<IEntretientService,EntretientService>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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
