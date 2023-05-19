using AutoMapper;
using BLL.Implementation;
using BLL.Interface;
using DAL.Implementation;
using DAL.Interface;

var builder = WebApplication.CreateBuilder(args);


// TODO: place connection string here or set envrimoment variable
//const string connectionString = "Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres";
string connectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? throw new ArgumentException("Missing env var: ConnectionString");



// Define automapper profiles

var config = new MapperConfiguration(cfg => {
    cfg.AddProfile<DAL.Profiles.MapperProfiles>();
});

IMapper mapper = new Mapper(config);


// Register services


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
    .AddTransient<IRoleService,RoleService>()
    .AddTransient<IOrderService,OrderService>()
    .AddTransient<IOrderStatusService, OrderStatusService>()
    .AddTransient<IMenuService,MenuService>()
    .AddTransient<ICustomProductSevice,CustomProductSevice>()
    .AddTransient<ICustomizedMenuProductsService,CustomizedMenuProductsService>();






// Add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/statuses",async (IOrderStatusService service) =>
{
    return await service.GetAllStatuses();
});

app.Run();
