The Rest Web API is developed in C# .NET Framework along with ENtity Framework for Data Connection. 

DataBase Setup:
A sample DataBase is hosted in Amazon RDB instance and is configured in web.config. 
The application can run without changing any configuration and will be able to retrieve data from the cloud Database.


In case the Database has to be changed, Please change the below DBConnection in Web.Config:
	<add name="GuidanceDbService" connectionString="data source=healthysavings.cbwxv8qttppa.ap-southeast-2.rds.amazonaws.com;initial catalog=Guidance;persist security info=True;user id=savehealth;password=logesh12;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />

To Deploy the Web API :

The Application is built without any error and the build is available under Publish Folder. 
Copy paste the build to IIS server to run the application. 