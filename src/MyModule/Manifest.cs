using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "MyModule",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "MyModule",
    Category = "MyModule",
    Dependencies = ["OrchardCore.Mvc"]
)]
