The database that I used in demo can be loaded with the script.sql file by running the script in Microsoft SQL Server.


Create_database.py is a file for creating database and generating data.
To execute the code, connection string should be modified.

db_connection = pyodbc.connect('Driver={SQL Server};'
                               'Server=DESKTOP-T1F4GD2;'                        <--
                               'Trusted_Connection=yes;', autocommit=True)

Server needs to be modified.



The application uses connection string in the config file.
To connect the application with the database, App.config file in Project1\Project1 folder and
Project1.exe.config file in Project1\Project1\bin\Debug folder.
****************************************************************
In App.config file

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
    </configSections>
    <connectionStrings>
        <add name="Project1.Properties.Settings.ProjectDBConnectionString"
            connectionString="Data Source=DESKTOP-T1F4GD2;Initial Catalog=ProjectDB;Integrated Security=True"  <--
            providerName="System.Data.SqlClient" />
    </connectionStrings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
</configuration>

Data Source needs to be modified.
*********************************************************************
In Project1.exe.config file

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
    </configSections>
    <connectionStrings>
        <add name="Project1.Properties.Settings.ProjectDBConnectionString"
            connectionString="Data Source=DESKTOP-T1F4GD2;Initial Catalog=ProjectDB;Integrated Security=True"   <--
            providerName="System.Data.SqlClient" />
    </connectionStrings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
</configuration>

Data Source needs to be modified.
**********************************************************************

To run the application, you need to run Project1.exe file in Project1\Project1\bin\Debug folder.