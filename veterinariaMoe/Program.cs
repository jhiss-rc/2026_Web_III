using Microsoft.EntityFrameworkCore;
using veterinariaMoe.Datos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});


builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VeterinariaDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
