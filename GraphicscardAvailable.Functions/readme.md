# Functions

https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#install-the-azure-functions-core-tools

https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection

## setup functions

create a new function app, remember its name

func azure functionapp fetch-app-settings *FunctionAppName*
func azure storage fetch-connection-string *functionappstorageaccount*

func new

func start --build

func azure functionapp publish *FunctionAppName*

## live metrics stream

func azure functionapp logstream *FunctionAppName* --browser
