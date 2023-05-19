// See https://aka.ms/new-console-template for more information
using DAL.Interface;
using DAL.Implementation;
using DAL;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DTO;
using Microsoft.EntityFrameworkCore.Internal;
using BLL.Implementation;
using BLL.Interface;

Console.WriteLine("Hello, World!");
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DAL.Profiles.MapperProfiles());
});

IMapper mapper = mapperConfig.CreateMapper();

const string connectionString = "Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres";

//IRoleRepository RoleRepository = new RoleRepository(mapper, connectionString);
IUserRepository userRepository = new UserRepository(mapper, connectionString);
IOrderRepository orderRepository = new OrderRepository(mapper, connectionString);
//IRegisterService registerServices = new RegisterService(userRepository);
IAuthenticationService authenticationService = new AuthenticationService(userRepository);
IOrderService orderService = new OrderService(orderRepository, userRepository);

//var user = await registerServices.RegisterUser("username", "email@mail.com", "password");
bool is_login = await authenticationService.LoginUser("username", "password");
Console.WriteLine(is_login);

var user = await userRepository.GetByUserName("username");


var order = await orderService.AddOrder(new OrderDTO
{
    UserId = user.UserId,
    OrderDate = DateOnly.FromDateTime(DateTime.Now)
});

order = await orderService.ProcessOrder(order.OrderId);
order = await orderService.CancelOrder(order.OrderId);
order = await orderService.ProcessOrder(order.OrderId);
order = await orderService.ProcessOrder(order.OrderId);
order = await orderService.ProcessOrder(order.OrderId);





//IOrderStatusRepository OrderStatusRepository = new OrderStatusRepository(mapper, "Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres");

//var statuses = await OrderStatusRepository.GetAllAsync();

//var res = await RoleRepository.GetAllAsync();

//Console.WriteLine(res.Count());