Watches for and closes the very stupid "ASIO" error spawned from the pits of Asus and bad software design.

Will not work as a Windows Service (because of window/desktop interaction), but can be spawned by the task scheduler.

Includes a publish configuration for publishing to C:\Program Files
* In Visual Studio, right click the .csproj file and click "Publish..."
* Select the "Publish to System Programs" configuration
* This will build and deploy the app to your C:\Program Files directory
	
You can then create a Task Scheduler item to start the app at login. It will run for no more than 5 minutes or when it sees and closes the Asus error dialog, whichever comes first.
