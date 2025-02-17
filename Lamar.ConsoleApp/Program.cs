// See https://aka.ms/new-console-template for more information

using Lamar;
using Lamar.IoC.DLL.Registry;
using Lamar.IoC.DLL.Services.Interfaces;

Container container = new Container(new MyRegistry());
IScopedService service = container.GetInstance<IScopedService>();
Console.WriteLine($"Scope 0 - Service: {service.GetOperationId()}");

using (INestedContainer scope1 = container.GetNestedContainer()) // Create first scope
{
    IScopedService serviceA = scope1.GetInstance<IScopedService>();
    IScopedService serviceB = scope1.GetInstance<IScopedService>();

    Console.WriteLine($"Scope 1 - Service A: {serviceA.GetOperationId()}");
    Console.WriteLine($"Scope 1 - Service B: {serviceB.GetOperationId()}");
}

using (INestedContainer scope2 = container.GetNestedContainer()) // Create second scope
{
    IScopedService serviceC = scope2.GetInstance<IScopedService>();

    Console.WriteLine($"Scope 2 - Service C: {serviceC.GetOperationId()}");
}

Console.ReadKey();
