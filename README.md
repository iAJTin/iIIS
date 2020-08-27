<p align="center">
  <img src="https://github.com/iAJTin/iIIS/blob/master/src/setup/resources/icon.png" height="32"/>
</p>
<p align="center">
  <a href="https://github.com/iAJTin/iIIS">
    <img src="https://img.shields.io/badge/iTin-iIIS-green.svg?style=flat"/>
  </a>
</p>

***

# What is iIIS?
iIIS is a lightweight implementation that allows you to install and add features to an Internet Information Services (IIS) installation using .NET code.

# Install via NuGet

<table>
  <tr>
    <td>
      <a href="https://github.com/iAJTin/iIIS">
        <img src="https://img.shields.io/badge/-iIIS-green.svg?style=flat"/>
      </a>
    </td>
    <td>
      <a href="https://www.nuget.org/packages/iIIS/">
        <img alt="NuGet Version" 
             src="https://img.shields.io/nuget/v/iIIS.svg" /> 
      </a>
    </td>  
  </tr>
</table>

# Usage

## Examples

1. Configures **IIS** features from custom features synchronously (For more information, please see **IIS.ConsoleApp** project)


       FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
       commands.Process();

2. Configures **IIS** features from custom features asynchronously (For more information, please see **IIS.ConsoleAsyncApp** project)


       FeatureCommandsCollection commands = Configurator.CreateCommands(Configurator.GetAllFeatures());
       await commands.ProcessAsync();

3. Configures **IIS** features from XML configuration file (For more information, please see **IIS.ConsoleApp** project)

     **XML** content file used for this example 

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

    .NET asynchronous Code:

       IISModel model = IISModel.LoadFromFile("~\\resources\\IIS-Features.xml");
       FeatureCommandsCollection commands = Configurator.CreateCommands(model);
       await commands.ProcessAsync();

# Installer

If you want to test the application, you can use the installer that is provided in the following link.

|Description|Version|
|:------|:------|
|iIISFeaturesSetup| [1.0.2] |


# How can I send feedback!!!

If you have found **iIIS** useful at work or in a personal project, I would love to hear about it. If you have decided not to use **iIIS**, please send me and email stating why this is so. I will use this feedback to improve **iIIS** in future releases.

My email address is 

![email.png][email] 

[1.0.2]: https://github.com/iAJTin/iIIS/tree/master/src/deliverables/v1.0.2

[email]: ./assets/email.png "email"
