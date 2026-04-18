using Microsoft.AspNetCore.Identity;
using MTStok.Domain.Entities;
using MTStok.Persistence;
using MTStok.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Eðer veriler bir þekilde silindiyse uygulama her baþladýðýnda çalýþýp, kullanýcý/rol yoksa ekleyecek blok
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Seeder metodumuzu çaðýrýyoruz
        await DbSeeder.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Veritabanýna baþlangýç verileri eklenirken bir hata oluþtu.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();