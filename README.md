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
-Already having experience in both frameworks


#If given more time or if this app needs to be enhanced, following points should be taken into consideration:

-As its a console app, FileSystemWatcher feature of microsoft should be used to make the application real time, eleminating any manual effort.
-data can be inserted or modified in batches and batch size should be defined in a config file.
-use of bulk insert/ bulk loader while pushing data into databases.
-As feeds can go upto millions in number, then to reduce program time , data parallelism should be implemented using plinq
-Right now, the application is error prone, so to handle this exception logging should be implemented.
-Files needs to be validated before converting into common models to handle invalid feeds.

