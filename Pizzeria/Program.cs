// See https://aka.ms/new-console-template for more information
using DAL.Interface;
using DAL.Implementation;
using DAL;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DTO;

Console.WriteLine("Hello, World!");
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DAL.Profiles.MapperProfiles());
});

IMapper mapper = mapperConfig.CreateMapper();

IRoleRepository RoleRepository = new RoleRepository(mapper, "Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres");
IOrderStatusRepository OrderStatusRepository = new OrderStatusRepository(mapper, "Host=localhost;Database=PizzeriaTest;Username=postgres;Password=postgres");

var statuses = await OrderStatusRepository.GetAllAsync();

var res = await RoleRepository.GetAllAsync();

Console.WriteLine(res.Count());