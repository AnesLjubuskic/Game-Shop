using GameShopBI.Services.CategoryService;
using GameShopBI.Services.EmailService;
using GameShopBI.Services.GameService;
using GameShopBI.Services.SubCategoryService;
using GameShopBI.Services.UserGameService;
using GameShopBI.Services.UserService;
using GameShopDA;
using GameShopDA.Repository.CategoryRepository;
using GameShopDA.Repository.GameRepository;
using GameShopDA.Repository.SubCategoryRepository;
using GameShopDA.Repository.UserGameRepository;
using GameShopDA.Repository.UserRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description="Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In=ParameterLocation.Header,
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddTransient<IGameRepository,GameRepository>();
builder.Services.AddTransient<IUserGameRepository,UserGameRepository>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubCategoryService,SubCategoryService>();
builder.Services.AddTransient<IGameService,GameService>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddTransient<IUserGameService,UserGameService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddAutoMapper(typeof(ICategoryService));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
             options => options
             .SetIsOriginAllowed(x => _ = true)
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials()
         ); //This needs to set everything allowed

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
