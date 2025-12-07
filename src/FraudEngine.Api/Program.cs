using FraudEngine.Infrastructure.Data;
using FraudEngine.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (using SQLite in-memory for testing)
builder.Services.AddDbContext<FraudDbContext>(options =>
    options.UseSqlite("Data Source=fraudengine.db"));

// Add repositories
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
