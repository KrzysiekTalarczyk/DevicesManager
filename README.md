# DevicesManager

DevicesManager.Client is a application for collecting information about current devices. 
Those information will be send to the server. The server url should be provided in appsettings.json e.g :
		
		{
			"ServerHubUrl": "http://localhost:5037/devicesHub" 
		}
		
		
		
DevicesManager.Server is a server application for collecting devices information and offers REST API.

How to use API filtering, sorting and pagination:
GET /Devices

?sorts=     hostName,-id         // sort by hostName, then descendingly by id 
&filters=   userName@=RT,     // filter devices where a hostName contains the phrase "RT"
&page=      1                                       // get the first page...
&pageSize=  3                                      // ...which contains 3 devices

Swagger UI example:
![filterring](/filtr_example.png)




		