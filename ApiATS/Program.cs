using ATSApi.Models;
using ATSApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CandidateDatabaseSettings>(
    builder.Configuration.GetSection("CandidateDatabase"));
builder.Services.Configure<PositionDatabaseSettings>(
    builder.Configuration.GetSection("PositionDatabase"));
builder.Services.AddSingleton<CandidatesService>();
builder.Services.AddSingleton<PositionsService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
