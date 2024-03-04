var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Use(async (context, next) =>
{
    // Get the user agent from the HTTP context if available
    string userAgent = context.Request.Headers["User-Agent"].ToString();

    // Print the user agent information
    if (!string.IsNullOrEmpty(userAgent))
    {
        context.Response.Headers.Add("X-User-Agent", userAgent);
    }
    else
    {
        context.Response.Headers.Add("X-User-Agent", "User Agent information not available.");
    }

    await next();
});









app.Run();
