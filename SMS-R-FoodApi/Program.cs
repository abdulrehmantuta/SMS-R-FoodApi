using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SMS_R_FoodApi.Data;
using SMS_R_FoodApi.Repository.IRepository;
using SMS_R_FoodApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS Policy Name
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// ✅ SQL Server Connection
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=db22163.public.databaseasp.net; Database=db22163; User Id=db22163; Password=Sz9#b!G7Qt5@; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;"));

// ✅ Dependency Injection
builder.Services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

// ✅ Swagger + API Explorer
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200", // Angular dev
                "https://abdulrehmantuta.github.io" // Live GitHub pages
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// ✅ Global Error Handler for Production
app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        Console.WriteLine($"🔥 ERROR: {exception?.Message}\n{exception?.StackTrace}");

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            error = "Internal Server Error",
            message = exception?.Message
        });
    });
});

// ✅ Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ✅ HTTPS
app.UseHttpsRedirection();

// ✅ CORS + Auth + Routing
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

// ✅ Run
app.Run();