using System.Data;
using DapperMvcDemo.Data.DataAccess;
using DapperMvcDemo.Data.Repository;
using Microsoft.Data.SqlClient; // Or use System.Data.SqlClient based on your preference

var builder = WebApplication.CreateBuilder(args);

// ✅ Register Services (Use Scoped Instead of Transient)
builder.Services.AddControllersWithViews();

// Register IDbConnection for SqlConnection
builder.Services.AddScoped<IDbConnection>(db =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// ✅ Handle Errors for Production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ✅ Middleware Configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ Set Default Route to Person Controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=DisplayAll}/{id?}");

app.Run();
