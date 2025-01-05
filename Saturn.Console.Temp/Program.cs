using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Saturn.Console.Temp;
using Saturn.Console.Temp.DataAccess;
using Saturn.Console.Temp.DI;
using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;




var services=ServiceProviderApp.GetServices();
var StudentService = services.GetRequiredService<IStudentDataAccess>();
await StudentService.Add(new Student()
{
    FullName = "deneme",
    GroupId = 1,
    Username = "test"
});


Console.WriteLine("Merhaba");