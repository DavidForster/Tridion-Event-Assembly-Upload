# Tridion Assembly Upload Event Handler

An SDL Tridion event handler to supersede `TcmUploadAssembly.exe`

## Synopsis

An event handler for SDL Tridion that responds to saves of .Net assembly TBBs and creates the corresponding C# "stub" TBBs, removing the need to upload code using the `TcmUploadAssembly.exe` command line tool and allowing easier uploading directly in the Content Management Explorer.

## Build Requirements

You will need to place the following non-distributable client assemblies from your SDL Tridion installation into the /References directory

 - `Tridion.Common.dll`
 - `Tridion.ContentManager.dll`
 - `Tridion.ContentManager.Templating.dll`

## Installation

Just like a regular event handler, copy the compiled assembly to your Content Management Server and add a new element to the `<extensions>` element of your `Tridion.ContentManager.config` file as follows

     <add assemblyFileName="X:\FullPathTo\DavidForster.Tridion.EventHandlers.AssemblyUpload.dll"/>

Restart your Tridion Content Manager Service Host service after installation and make sure that the event handler is loaded by checking your Tridion event log.

## License

Licensed under the terms of the [GNU General Public License v2.0](http://www.gnu.org/licenses/gpl-2.0.txt)