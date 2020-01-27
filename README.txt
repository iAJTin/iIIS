
What is iSMBIOS?
================

iIIS is a lightweight implementation that allows you to install and add features to an Internet Information Services (IIS) installation using .NET code.

Library versions
================

Library versions for current iIIS version (1.0.0)

•————————————————————————————————————————————————————————————————————————————————————————————————————•
| Library                 Version       Description                                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.Min            1.0.0         Common calls                                                 |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.IO             1.0.0		    IO Supports To Network Drives, Reletive Paths (~), Native IO |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Core.Models         1.0.0	    	XML and Json Models classes                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.Registry.Windows    1.0.0		    DMI Specification Implementation                             |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
|iTin.AspNet.Web.IIS      1.0.0		    Internet Information Services Library Calls                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•

Install via NuGet
=================

For more information, please see https://www.nuget.org/packages/iIIS/

Usage
=====

Examples
--------

1. Configures IIS features from custom features (For more information, please see IIS.ConsoleAPP project)

    FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
    commands.Process();


2. Configures IIS features from XML configuration file (For more information, please see IIS.ConsoleAPP project)

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

    .NET Code:

       IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
       FeatureCommandsCollection commands = Configurator.CreateCommands(model);
       commands.Process();
