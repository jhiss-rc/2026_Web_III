var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc().AddViewOptions(options =>
{
    options.HtmlHelperOptions.ClientValidationEnabled = true;
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "El campo es obligatorio");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "El valor ingresado no es válido");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(_ => "El valor ingresado no es válido");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
