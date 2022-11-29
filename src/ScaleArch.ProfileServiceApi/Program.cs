using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ScaleArch.ProfileServiceApi.Data;
using ScaleArch.Sql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProfileServiceDbContext>(options =>
            options
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(1), null))
            .ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning)));

builder.Services.AddScoped<DbContext>(p =>
{
    var profileServiceDbContext = p.GetService<ProfileServiceDbContext>();
    return profileServiceDbContext;
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var context = scope.ServiceProvider.GetService<ProfileServiceDbContext>();
context.Database.Migrate();


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
