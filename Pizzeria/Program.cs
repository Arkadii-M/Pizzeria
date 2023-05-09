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

IRepository<RoleDTO> RoleRepository = new RoleRepository(mapper);
IRepository<OrderStatusDTO> OrderStatusRepository = new OrderStatusRepository(mapper);

var statuses = await OrderStatusRepository.GetAllAsync();

var res = await RoleRepository.GetAllAsync();

Console.WriteLine(res.Count());