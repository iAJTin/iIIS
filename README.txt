
What is iSMBIOS?
================

iIIS is a lightweight implementation that allows you to install and add features to an Internet Information Services (IIS) installation using .NET code.

Changes in this version
=======================

· Fixed
  -----
 - Fixes an xml schema-related problem that prevents the xml configuration file from being properly processed.

· Added
  -----
 - Adds support for asynchronous processing calls, please see new projects added to the solution for more information

 - Adds two new projects to solution:
 
   \root
     - test
       - IIS.ConsoleAsyncApp  [Console Test Async App]
       - IIS.FormsAsyncApp    [Windows Forms Test Async App]

Library versions
================

Library versions for current iIIS version (1.0.1)

•————————————————————————————————————————————————————————————————————————————————————————————————————•
| Library                 Version       Description                                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.Min            1.0.0         Common calls                                                 |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.IO             1.0.0         IO Supports To Network Drives, Reletive Paths (~), Native IO |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.Models         1.0.0         XML and Json Models classes                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Registry.Windows    1.0.0         Windows Registry Calls                                       |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.AspNet.Web.IIS      1.0.1         Internet Information Services Library Calls                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•

Install via NuGet
=================

For more information, please see https://www.nuget.org/packages/iIIS/

Usage
=====

Examples
--------

1. Configures IIS features from custom features synchronously (For more information, please see IIS.ConsoleApp project)

    FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
    commands.Process();

2. Configures IIS features from custom features asynchronously (For more information, please see IIS.ConsoleAsyncApp project)

    FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
    await commands.ProcessAsync();

3. Configures IIS features from XML configuration file (For more information, please see IIS.ConsoleApp project)

    XML content file used for this example 

    <?xml version="1.0" encoding="utf-8"?>
    <IIS xmlns="http://schemas.itin.com/utilities/iis/configurator/v1.0">
        <Configuration>
        <Features>
            <Feature Name="WebServerRole"/>
            <Feature Name="WebServer"/>
            <Feature Name="CommonHttpFeatures"/>
            <Feature Name="HttpErrors"/>
            <Feature Name="HttpRedirect"/>
            <Feature Name="NetFxExtensibility"/>
            <Feature Name="HealthAndDiagnostics"/>
            <Feature Name="HttpLogging"/>
            <Feature Name="HttpTracing"/>
            <Feature Name="Security"/>
            <Feature Name="RequestFiltering"/>
            <Feature Name="IPSecurity"/>
            <Feature Name="Performance"/>
            <Feature Name="WebServerManagementTools"/>
            <Feature Name="IIS6ManagementCompatibility"/>
            <Feature Name="Metabase"/>
            <Feature Name="StaticContent"/>
            <Feature Name="DefaultDocument"/>
            <Feature Name="DirectoryBrowsing"/>
            <Feature Name="ISAPIExtensions"/>
            <Feature Name="ISAPIFilter"/>
            <Feature Name="ASPNET"/>
            <Feature Name="CustomLogging"/>
            <Feature Name="BasicAuthentication"/>
            <Feature Name="HttpCompressionStatic"/>
            <Feature Name="ManagementConsole"/>
            <Feature Name="ManagementService"/>
            <Feature Name="WMICompatibility"/>
            <Feature Name="LegacyScripts"/>
            <Feature Name="WindowsAuthentication"/>
        </Features>
        </Configuration>
    </IIS>

    .NET synchronous Code:

       IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
       FeatureCommandsCollection commands = Configurator.CreateCommands(model);
       commands.Process();

    .NET asynchronous Code: (Please see async projects for more information)

       IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
       FeatureCommandsCollection commands = Configurator.CreateCommands(model);
       await commands.ProcessAsync();
