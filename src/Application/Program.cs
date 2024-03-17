using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

#region Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(
        config.GetConnectionString("DefaultConnection"),
        sqlServerOptions =>
        {
            sqlServerOptions.MigrationsAssembly("Application"); // Specify the assembly containing migrations
            sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            ); // Enable retry logic for transient failures
        }
    );
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("ECommerce8", new OpenApiInfo { Title = "ECommerce8", Version = "v1" });
    c.SwaggerDoc("CSharpTopics", new OpenApiInfo { Title = "CSharpTopics", Version = "v1" });
    c.SwaggerDoc("Algorithms", new OpenApiInfo { Title = "Algorithms", Version = "v1" });
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyHeader().WithOrigins("https://localhost:4200");
    });
});

#region AddScoped region for repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
#endregion

#region AddScoped region for domain services
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddScoped<IMockDataDomainService, MockDataDomainService>();
#endregion

#region AddScoped region for application services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICSharpTopicsService, CSharpTopicsService>();
builder.Services.AddScoped<IMockDataService, MockDataService>();
#endregion

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/ECommerce8/swagger.json", "ECommerce8");
        c.SwaggerEndpoint("/swagger/CSharpTopics/swagger.json", "CSharpTopics");
        c.SwaggerEndpoint("/swagger/Algorithms/swagger.json", "Algorithms");
    });
}

//app.UseMiddleware<ExceptionMiddleware>();
//app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyOrigin();
});
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseHttpsRedirection();
app.MapControllers();

#endregion

app.Run();

/* .net 6 onwards now allows integration of startup into program.cs! */