using System.Reflection;
using ReflectionSample;

var currentAssembly = Assembly.GetExecutingAssembly();

var oneTypeFromCurrentAssembly = currentAssembly.GetType("ReflectionSample.Person");

foreach (var constructor in oneTypeFromCurrentAssembly.GetConstructors())
{
    Console.WriteLine(constructor);
}

foreach (var method in oneTypeFromCurrentAssembly.GetMethods(
             BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
{
    Console.WriteLine(method);
}


Console.ReadLine();


void TypesAndModules()
{
    var typesFromCurrentAssembly = currentAssembly.GetTypes();

    // Print all types from current Assembly
    foreach (var type in typesFromCurrentAssembly)
    {
        Console.WriteLine(type.Name);
    }

    // Get type for Person in current module
    var oneTypeFromCurrentAssembly = currentAssembly.GetType("ReflectionSample.Person");

    // Get type from external assembly
    var externalAssembly = Assembly.Load("System.Text.Json");
    var oneTypeFromExternalAssembly = externalAssembly.GetType("System.Text.Json.JsonProperty");

    // Get module from external assembly
    var modulesFromExternalAssembly = externalAssembly.GetModules();
    var oneModuleFromExternalAssembly = externalAssembly.GetModule("System.Text.Json.dll");

    // Get types from module from external assembly
    var typesFromModuleFromExternalAssembly = oneModuleFromExternalAssembly.GetTypes();
    var oneTypeFromModuleFromExternalAssembly = oneModuleFromExternalAssembly.GetType("System.Text.Json.JsonProperty");
}