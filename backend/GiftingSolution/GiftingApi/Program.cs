oncall-developer-api-serviceusing GiftingApi.Adapters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Setting up our "Services"
builder.Services.AddTransient<ICatalogPeople, EfPeopleCatalog>(); // hey, API, if you need an ICatalogPeople, use this class.

builder.Services.AddDbContext<GiftingDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("gifts"));
});

builder.Services.AddHttpClient<OnCallLookupApiAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("developer-api"));
});

// Example of CORS (Cross Origin Resource Sharing)
builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(pol =>
    {   // "Promiscuous Mode"
        pol.AllowAnyHeader();
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();
