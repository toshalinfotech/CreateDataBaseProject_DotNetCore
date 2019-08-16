# CreateDataBaseProject_DotNetCore
Developer (Anuja Patel)

Prerequisites
	Visual Studio 2017 version 15.7 or later with these workloads:
	ASP.NET and web development (under Web & Cloud)
	.NET Core cross-platform development (under Other Toolsets)
	.NET Core 2.1 SDK.

Create a new project
	Open Visual Studio 2017
	File > New > Project
	From the left menu, select Installed > Visual C# > .NET Core.
	Select ASP.NET Core Web Application.
	Enter EFGetStarted.AspNetCore.NewDb for the name and click OK.
	In the New ASP.NET Core Web Application dialog:
	Make sure that .NET Core and ASP.NET Core 2.1 are selected in the drop-down lists
	Select the Web Application (Model-View-Controller) project template
	Make sure that Authentication is set to No Authentication
	Click OK

Create the model which consists of table sets and implements DbContext interface.

Create the database
	Tools > NuGet Package Manager > Package Manager Console
	Run the following commands:
		Add-Migration InitialCreate
		Update-Database

If you get an error stating The term 'add-migration' is not recognized as the name of a cmdlet, close and reopen Visual Studio.

The Add-Migration command scaffolds a migration to create the initial set of tables for the model. The Update-Database command creates the database and applies the new migration to it.

Create a controller
	Right-click on the Controllers folder in Solution Explorer and select Add > Controller.
	Select MVC Controller with views, using Entity Framework and click Add.
	Set Model class and Data context class.
	Click Add.
	
The scaffolding engine creates the following files:

A controller (Controllers/*.cs)
Razor views for Create, Delete, Details, Edit, and Index pages (Views/*/*.cshtml)