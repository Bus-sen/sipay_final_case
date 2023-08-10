using AutoMapper;
using Data;
using Data.Uow;
using Microsoft.EntityFrameworkCore;
using Schema.Mapper;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SipayDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"))
);

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperConfig());
});
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IHouseholderService, HouseholderService>();
builder.Services.AddScoped<IHouseDetailService, HouseDetailService>();
builder.Services.AddScoped<IBillService, BillService>();



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
