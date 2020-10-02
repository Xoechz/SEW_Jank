# SEW_Jank Mitschrift
3 Schichten Architektur

	mehr Schichten möglich(z.B. Maschinensteuerung mit Router)
	3 Schichten in Webapplikationen
	-------------------------
	|PL - Presentation Layer|
	-------------------------------------------------
	↕ Webservices (z.B. Rest, SOAP)	|Businessobjekte|
	-------------------------------------------------
	|BL - Buisnesslogic     |	Unittests geeignet
	------------------------------------------------
	↕				|Domänenobjekte|
	------------------------------------------------
	|DAL - Data Access Layer|	Unittests geeignet
	|(z.B. Entity Framework)|
	-------------------------
	↕
	Datenbank (austauschbar, Testdatenbank)
	
	Einzelne Schichten sind austauschbar, jedoch solte man Schichten nicht überspringen(z.B. BL greift auf die Datenbank zu, führt zu Data Inconsistency)
	Programmiertechnisch ist es am besten, wenn jede Schicht ein fixes Interface besitz um die Daten mit anderen Schichten auszutauschen, die Implementierung kann dadurch geändert werden, da die Schichten nur mit dem Interface kommunizieren.


Sprachen Vergleich

	Java
		Write Once Run Anywhere
		Sourcecode -> Java Compiler -> Java Bytecode -> Java Virtual Machine(JVM) -> Any Hardware
		
	.NET
		Sourcecode -> Compiler -> Zwischensprache(Microsoft Intermediate Language(MSIL)) -> Maschinencode
		WPF, Windows Forms, ASP.NET(4&5)
		.NET Framework 4.6(Windows)
	
	.NET Core
		ASP.NET5, Universal Windows Apps
		.NET Core 5
			CoreCLR(macOS, Linux, Windows)
			.NET Native(Windows)
	
	.NET & .NET Core
		shared Runtime Components, Libraries, Compilers(.NET Compiler Platform(Roslyn))
	
	
	
	ASP.NET Core
		Windows, macOS Linux
		Razor Pages for Web UI
		multiple versions per machine
		Visual Studio, VS for Mac or VS Code
		Higher performance than ASP.NET 4.x
		Use .NET Core runtime
	
	ASP.NET 4.x
		Windows
		Web Forms, SignalR, MVC, Web API, WebHooks or WebPages
		one version per machine
		VisualStudio
		Good Performance
		Use .NET Framework runtime
				

Dependency injection
	https://docs.microsoft.com/de-de/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2

Designpatterns
	I muas ehrlich song ka ahnung wos ma mochn.

