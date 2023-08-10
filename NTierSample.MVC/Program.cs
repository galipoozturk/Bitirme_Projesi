using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using NTierSample.BLL;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NTierSample.BLL.Abstract;
using NTierSample.BLL.Concrete;
using NTierSample.DAL.Concrete;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NTierSampleMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'NTierSampleMVCContextConnection' not found.");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScopeBLL();
builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddScoped<NTierSampleDbContext, NTierSampleDbContext>();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    // custom scheme defined in .AddPolicyScheme() below
    options.DefaultScheme = "JWT_OR_COOKIE";
    options.DefaultChallengeScheme = "JWT_OR_COOKIE";
})
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    })
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidIssuer = "localhost",
            ValidateAudience = false,
            ValidAudience = "localhost",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("test12531251254612545126565365162537512536512765371523127231231"))
        };
    })
    // this is the key piece!
    .AddPolicyScheme("JWT_OR_COOKIE", "JWT_OR_COOKIE", options =>
    {
        // runs on each request
        options.ForwardDefaultSelector = context =>
        {
            // filter by auth type
            string authorization = context.Request.Headers[HeaderNames.Authorization];
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                return "Bearer";

            // otherwise always check for cookie auth
            return "Cookies";
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});



app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
