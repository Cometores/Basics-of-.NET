using System.Reflection;
using ReflectionSample;

var currentAssembly = Assembly.GetExecutingAssembly();
var oneTypeFromCurrentAssembly = currentAssembly.GetType("ReflectionSample.Person");

var personType = typeof(Person);
var personConstructors = personType.GetConstructors(
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

foreach (var personConstructor in personConstructors)
{
    Console.WriteLine(personConstructor);
}

var privatePersonConstructor = personType.GetConstructor(
    BindingFlags.Instance | BindingFlags.NonPublic,
    null,
    new[] { typeof(string), typeof(int) },
    null);

var person1 = personConstructors[0].Invoke(null);
var person2 = personConstructors[1].Invoke(new object[] { "Andrey" });
var person3 = personConstructors[2].Invoke(new object[] { "Andrey", 24 });

var person4 = Activator.CreateInstance("ReflectionSample", "ReflectionSample.Person");

var person5 = Activator.CreateInstance("ReflectionSample",
    "ReflectionSample.Person",
    true,
    BindingFlags.Instance | BindingFlags.Public,
    null,
    new object[] { "Andrey" },
    null,
    null);

var personTypeFromString = Type.GetType("ReflectionSample.Person");
var person6 = Activator.CreateInstance(personTypeFromString, new object[] { "Andrey" });

var person7 = Activator.CreateInstance("ReflectionSample",
    "ReflectionSample.Person",
    true,
    BindingFlags.Instance | BindingFlags.NonPublic,
    null,
    new object[] { "Andrey", 24},
    null,
    null);

var assembly = Assembly.GetExecutingAssembly();
var person8 = assembly.CreateInstance("ReflectionSample.Person");

Console.ReadLine();


void MethodsAndConstructors()
{
    foreach (var constructor in oneTypeFromCurrentAssembly.GetConstructors())
    {
        Console.WriteLine(constructor);
    }

    foreach (var method in oneTypeFromCurrentAssembly.GetMethods(
                 BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    {
        Console.WriteLine(method);
    }
}

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