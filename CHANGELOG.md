# Changelog

All notable changes to this project will be documented in this file.

## [1.0.3] - 

### Fixed

-

### Added

-

### Changed

- Library versions for this version
  
|Library|Version|Description|
|:------|:------|:----------|
|iTin.Core.Min| 1.0.0 | Common calls |
|iTin.Core.IO| 1.0.0 | IO Supports To Network Drives, Reletive Paths (~), Native IO |
|iTin.Core.Models| 1.0.0 | XML and Json Models classes |
|iTin.Registry.Windows| 1.0.0 | Windows Registry Calls  |
|iTin.AspNet.Web.IIS| **1.0.3** | Internet Information Services Library Calls |

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

[1.0.0]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.0
[1.0.1]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.1
[1.0.2]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.2
[1.0.3]: https://github.com/iAJTin/iIIS/releases/tag/v1.0.3
