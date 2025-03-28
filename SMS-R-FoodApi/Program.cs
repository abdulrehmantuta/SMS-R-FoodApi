//using Microsoft.EntityFrameworkCore;
//using SMS_R_FoodApi.Data;
//using SMS_R_FoodApi.Repository.IRepository;
//using SMS_R_FoodApi.Repository;

//var builder = WebApplication.CreateBuilder(args);

//// CORS Policy Name
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//// Add services to the container.
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
//builder.Services.AddScoped<IItemRepository, ItemRepository>();
//builder.Services.AddScoped<ISaleRepository, SaleRepository>();
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// ?? Add CORS Policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:4200") // Angular App Ka Origin
//                  .AllowAnyMethod()
//                  .AllowAnyHeader()
//                  .AllowCredentials();
//        });
//});

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// ?? Use CORS Middleware (Important)
//app.UseCors(MyAllowSpecificOrigins);

//app.UseAuthorization();
//app.MapControllers();
//app.Run();


using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Data;
using SMS_R_FoodApi.Repository.IRepository;
using SMS_R_FoodApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy Name
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ? Add CORS Policy (Updated)
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200",  // Local Development
            "https://abdulrehmantuta.github.io"  // GitHub Pages Frontend
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ? CORS Middleware Enable (Fix)
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();
app.Run();
