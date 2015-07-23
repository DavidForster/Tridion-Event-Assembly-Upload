# Tridion Assembly Upload Event Handler

An SDL Tridion event handler alternative to `TcmUploadAssembly.exe`

## Synopsis

An event handler for SDL Tridion that responds to saves of .Net assembly TBBs and creates the corresponding C# "stub" TBBs, removing the need to upload code using the `TcmUploadAssembly.exe` command line tool and allowing easier uploading directly in the Content Management Explorer or even WebDAV.

## Usage

Once installed, you no longer need to upload your compiled .Net assembly TBBs using `TcmUploadAssembly.exe`.

### Content Manager Explorer

Browse to the location where you wish to store your templates and create a new Template Building Block. In the Source tab, change the Template Type to .Net Assembly and you will be given the option to Load from Disk. Just choose your DLL then Save and Close.

### WebDAV

If you have a WebDAV connection to your Content Manager Server, you can change the DLL's file extension to .tbbasm and simply copy it across.

### Core Service

The Event Handler should also take care of any .Net Assembly Template Building Blocks created via Core Service.

## Download

To download the latest official release in source or compiled form, see the project's [releases page](https://github.com/DavidForster/Tridion-Event-Assembly-Upload/releases) on GitHub.

## Installation

Just like a regular event handler, copy the compiled assembly to your Content Management Server and add a new element to the `<extensions>` element of your `Tridion.ContentManager.config` file as follows

     <add assemblyFileName="X:\FullPathTo\DavidForster.Tridion.EventHandlers.AssemblyUpload.dll"/>

Restart your Tridion Content Manager Service Host service after installation and make sure that the event handler is loaded by checking your Tridion event log.

## Build Requirements

If you wish to build the Event Handler from source, you will need to place the following non-distributable client assemblies from your SDL Tridion installation into the /References directory

 - `Tridion.Common.dll`
 - `Tridion.ContentManager.Common.dll`
 - `Tridion.ContentManager.dll`
 - `Tridion.ContentManager.Templating.dll`

## License

Licensed under the terms of the [GNU General Public License v2.0](http://www.gnu.org/licenses/gpl-2.0.txt)
