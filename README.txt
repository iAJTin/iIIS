
What is iIIS ?
================

iIIS is a lightweight implementation that allows you to install and add features to an Internet Information Services (IIS) installation using .NET code.

Changes in this version
=======================

· Added
  -----
  - Add new libraries and remove old libraries for compability with another libraries.
  - New delivery published v1.0.3

· Removed
  -------
    - Library removed for this version

    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | Library                 Version       Description                                                            |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Min            1.0.0        Common calls                                                           |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•

· Changed
  -------
  - Uses new IResult implementations in iTin.Core (only for internal use), no affect to existent apps.
  - Library versions for this version

    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | Library                 Version       Description                                                            |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core               2.0.0.0        Base library containing various extensions, helpers, common constants |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.IO            1.0.0.0        IO Supports To Network Drives, Reletive Paths (~), Native IO          |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Core.Models        1.0.0.0        XML and Json Models classes                                           |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Registry.Windows   1.0.0.0        Windows Registry Calls                                                |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.AspNet.Web.IIS     1.0.0.3        Internet Information Services Library Calls                           |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    | iTin.Logging            1.0.0.0        Internet Information Services Library Calls                           |
    •——————————————————————————————————————————————————————————————————————————————————————————————————————————————•

v1.0.2
=======================

· Fixed
  -----
 - Fixes an xml schema-related problem that prevents the xml configuration file from being properly processed.

· Added
  -----
  - Adds support for asynchronous processing calls, please see new projects added to the solution for more information

  - Adds two new projects to solution:
 
    \ root
      \ src
        \ deliverables
          · vX.X.X            [Windows Installer], where: X.X.X => Version number (current v1.0.2)
        \ setup
          · iIISFeaturesSetup [Console Test Async App]
          · resources         [Shared installer resources]
        \ util
          · vs-extensions     [Microsoft Installer Visual Studio Extension (2017/2019)]

Library versions
================

Library versions for current iIIS version (1.0.2)

•————————————————————————————————————————————————————————————————————————————————————————————————————•
| Library                 Version       Description                                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
| iTin.Core.Min            1.0.0        Common calls                                                 |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
| iTin.Core.IO             1.0.0        IO Supports To Network Drives, Reletive Paths (~), Native IO |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
| iTin.Core.Models         1.0.0        XML and Json Models classes                                  |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
| iTin.Registry.Windows    1.0.0        Windows Registry Calls                                       |
•————————————————————————————————————————————————————————————————————————————————————————————————————•
| iTin.AspNet.Web.IIS      1.0.2        Internet Information Services Library Calls                  |
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

