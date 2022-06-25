# Changelog

All notable changes to this project will be documented in this file.

## [1.0.4] - 2022-06-25

### Fixes

 - Upgrade Newtonsoft.Json nuget package to version 13.0.1 (without critical errors) and others nuget packages

### Changed

 - Changed **```IResultGeneric```** interface. Changed **```Value```** property name by **```Result```** (for code clarify).
 
       This change may have implications in your final code, it is resolved by changing Value to Result

 - Updated result classes for support more scenaries.
 
 - Library versions for this version
  
    | Library | Version | Description |
    |:------|:------|:----------|
    | iTin.AspNet.Web.IIS | **1.0.0.4** | Internet Information Services Library Calls |
    | iTin.Core| **2.0.0.3** | Base library containing various extensions, helpers, common constants |
	| iTin.Core.IO | 1.0.0.0 | Common I/O calls |
	| iTin.Core.Models | **1.0.0.1** | Data models base |
    | iTin.Logging| **1.0.0.1** | Logging library |
  	| iTin.Registry.Windows | **1.0.0.1** | Windows registry access |
 
 ### Added

  - New delivery published [Delivery 1.0.4].


## [1.0.3] - 2020-10-10

### Added

- Add new libraries and remove old libraries for compability with another libraries.
- New delivery published [Delivery 1.0.3].

### Removed

- Library removed for this version

|Library|Version|Description|
|:------|:------|:----------|
|iTin.Core.Min| 1.0.0 | Common calls |

### Changed

- Uses new **IResult** implementations in **iTin.Core** (only for internal use), no affect to existent apps.

- Library versions for this version
  
| Library | Version | Description |
|:------|:------|:----------|
| iTin.Core | 2.0.0.0 | Base library containing various extensions, helpers, common constants |
| iTin.Core.IO | 1.0.0.0 | IO Supports To Network Drives, Reletive Paths (~), Native IO |
| iTin.Core.Models | 1.0.0.0 | XML and Json Models classes |
| iTin.Registry.Windows | 1.0.0.0 | Windows Registry Calls  |
| iTin.AspNet.Web.IIS | **1.0.0.3** | Internet Information Services Library Calls |
| iTin.Logging | 1.0.0.0 | Logging library |

## [1.0.2] - 2020-08-04

### Fixed

- Fixes xml namespace in model sample.

### Added

- Adds windows installer project (iIISFeaturesSetup)

- Adds two new projects to solution:

      \- root 
        \- src
           \- deliverables
              · vX.X.X            [Windows Installer], where: X.X.X => Version number (current = 1.0.2)
           \- setup
              · iIISFeaturesSetup [Console Test Async App]
              · resources         [Shared installer resources]
        \- util
           · vs-extensions        [Microsoft Installer Visual Studio Extension (2017/2019)]

### Changed

- Library versions for this version
  
|Library|Version|Description|
|:------|:------|:----------|
|iTin.Core.Min| 1.0.0 | Common calls |
|iTin.Core.IO| 1.0.0 | IO Supports To Network Drives, Reletive Paths (~), Native IO |
|iTin.Core.Models| 1.0.0 | XML and Json Models classes |
|iTin.Registry.Windows| 1.0.0 | Windows Registry Calls  |
|iTin.AspNet.Web.IIS| **1.0.2** | Internet Information Services Library Calls |


## [1.0.1] - 2020-03-21

### Fixed

- Fixes an xml schema-related problem that prevents the xml configuration file from being properly processed.

### Added

- Adds support for asynchronous processing calls, please see new projects added to the solution for more information

- Adds two new projects to solution:

      \ root
        - test
            - IIS.ConsoleAsyncApp  [Console Test Async App]
            - IIS.FormsAsyncApp    [Windows Forms Test Async App]

### Changed

- Library versions for this version
  
|Library|Version|Description|
|:------|:------|:----------|
|iTin.Core.Min| 1.0.0 | Common calls |
|iTin.Core.IO| 1.0.0 | IO Supports To Network Drives, Reletive Paths (~), Native IO |
|iTin.Core.Models| 1.0.0 | XML and Json Models classes |
|iTin.Registry.Windows| 1.0.0 | Windows Registry Calls  |
|iTin.AspNet.Web.IIS| **1.0.1** | Internet Information Services Library Calls |

## [1.0.0] - 2020-01-27

### Added

- Create project and first commit

- Solution structure

      \ root
        - lib
          - iTin.AspNet             
            - iTin.AspNet.Web.IIS               [Internet Information Services Library Calls] 
          - iTin.Core             
            - iTin.Core.IO                      [IO Supports To Network Drives, Reletive Paths (~), Native IO] 
            - iTin.Core.Min                     [Common Calls] 
            - iTin.Core.Models                  [XML and Json Models classes]
          - iTin.Resgistry    
            - iTin.Registry.Windows             [Windows Registry Calls] 
        - test
            - IIS.ConsoleApp                    [Console Test App]
            - IIS.FormsApp                      [Windows Forms Test App]

- Library versions for this version
  
|Library|Version|Description|
|:------|:------|:----------|
|iTin.Core.Min| 1.0.0 | Common calls |
|iTin.Core.IO| 1.0.0 | IO Supports To Network Drives, Reletive Paths (~), Native IO |
|iTin.Core.Models| 1.0.0 | XML and Json Models classes |
|iTin.Registry.Windows| 1.0.0 | Windows Registry Calls  |
|iTin.AspNet.Web.IIS| 1.0.0 | Internet Information Services Library Calls |

[1.0.4]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.4
[1.0.3]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.3
[1.0.2]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.2
[1.0.1]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.1
[1.0.0]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.0

[Delivery 1.0.4]: https://github.com/iAJTin/iIIS/tree/master/src/deliverables/v1.0.4
[Delivery 1.0.3]: https://github.com/iAJTin/iIIS/tree/master/src/deliverables/v1.0.3
