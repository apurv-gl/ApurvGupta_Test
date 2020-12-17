# ApurvGupta_Test

#How to execute the code?
- Go to ImportFeeds > bin > debug >
- Run ImportFeeds.exe
- It will prompt for file path (local file path)
- Feeds will start importing

#Code structure
- Program.cs : entry point of application
- Services : contains required contracts and implementations (Business logic)
- Data : dataabse layer to communicate with Databases
- Models : contais DTOs
- DI> SetupIoC.cs : Initialization of IoC container and dependencies using structureMap
- Automapper > AutoMapperConfig.cs : Used to configure object mappings

#StructureMap is used for dependency injection
#NUnit is used to write unit test cases
#Already having experience in both frameworks. 