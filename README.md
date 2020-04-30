Sample ASP.NET Core app (based on .NET Core 3.1) to demonstate how to implement action filters. 

The demo implements an action filter that uses feature toggles to determine if endpoints should be implemented in the current environment. It also implements an attribute to allow annotating actions with the feature toggle that determines if they are allowed to be called.

