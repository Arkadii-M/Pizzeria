using AutoMapper;
using BLL.Implementation;
using BLL.Interface;
using DAL.Implementation;
using DAL.Interface;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

var builder = WebApplication.CreateBuilder(args);


string connectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? throw new ArgumentException("Missing env var: ConnectionString");

string issuer = Environment.GetEnvironmentVariable("Issuer") ?? throw new ArgumentException("Missing env var: Issuer");
string audience = Environment.GetEnvironmentVariable("Audience") ?? throw new ArgumentException("Missing env var: Audience");
string signingKey = Environment.GetEnvironmentVariable("SigningKey") ?? throw new ArgumentException("Missing env var: SigningKey");



// Define automapper profiles

var config = new MapperConfiguration(cfg => {
    cfg.AddProfile<DAL.Profiles.MapperProfiles>();
});

IMapper mapper = new Mapper(config);


// Register services

builder.Services
    .AddSingleton<ITokenService, TokenService>(_ => new TokenService(issuer,audience,signingKey));

builder.Services
    .AddTransient<IUserRepository,UserRepository>(_ => new UserRepository(mapper,connectionString))
    .AddTransient<IUserStatusRepository, UserStatusRepository>(_ => new UserStatusRepository(mapper, connectionString))
    .AddTransient<IRoleRepository, RoleRepository>(_ => new RoleRepository(mapper, connectionString))
    .AddTransient<IOrderStatusRepository, OrderStatusRepository>(_ => new OrderStatusRepository(mapper, connectionString))
    .AddTransient<IOrderRepository, OrderRepository>(_ => new OrderRepository(mapper, connectionString))
    .AddTransient<IOrderDetailRepository, OrderDetailRepository>(_ => new OrderDetailRepository(mapper, connectionString))
    .AddTransient<IMenuRepository, MenuRepository>(_ => new MenuRepository(mapper, connectionString))
    .AddTransient<IItemTypeRepository, ItemTypeRepository>(_ => new ItemTypeRepository(mapper, connectionString))
    .AddTransient<ICustomProductRepository, CustomProductRepository>(_ => new CustomProductRepository(mapper, connectionString))
    .AddTransient<ICustomizedMenuProductRepository, CustomizedMenuProductRepository>(_ => new CustomizedMenuProductRepository(mapper, connectionString));


builder.Services
    .AddTransient<IAuthenticationService, AuthenticationService>()
    .AddTransient<IRegisterService,RegisterService>()
    .AddTransient<IUserService, UserService>()
    .AddTransient<IRoleService,RoleService>()
    .AddTransient<IOrderService,OrderService>()
    .AddTransient<IOrderStatusService, OrderStatusService>()
    .AddTransient<IMenuService,MenuService>()
    .AddTransient<ICustomProductSevice,CustomProductSevice>()
    .AddTransient<ICustomizedMenuProductsService,CustomizedMenuProductsService>();






// Add swagger
var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

var contact = new OpenApiContact()
{
    Name = "Mohamad Lawand",
    Email = "hello@mohamadlawand.com",
    Url = new Uri("http://www.mohamadlawand.com")
};

var license = new OpenApiLicense()
{
    Name = "Free License",
    Url = new Uri("http://www.mohamadlawand.com")
};

var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Minimal API - JWT Authentication with Swagger demo",
    Description = "Implementing JWT Authentication in Minimal API",
    TermsOfService = new Uri("http://www.example.com"),
    Contact = contact,
    License = license
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});





builder.Services.AddControllers();

//// Add swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


// Enable cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options =>
    {
        options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Authorization
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,

            ValidateAudience = true,
            ValidAudience = audience,

            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
            ValidateIssuerSigningKey = true,
        };
    });




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/statuses",async (IOrderStatusService service) =>
//{
//    return await service.GetAllStatuses();
//});

//app.MapAccountEndpoints();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();
