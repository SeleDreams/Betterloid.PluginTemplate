# Betterloid Plugin Template

## Introduction

This template project is a great base to learn how to make VOCALOID5 plugins.

All the code here is commented and shows some of the most common tasks done by plugins, by using this template you'll be able to do various tasks.

The template contains demo code that :

- Displays an XAML dialog box when started, this dialog box contains two buttons.

- When button 1 is clicked, the plugin will create a vocaloid track and put two notes with different lyrics inside.

- When button 2 is clicked, the plugin will check the currently selected notes and change their lyrics to "la"


## Installation

To start using this template project, you will need to first get Visual Studio 2019.

You can install it for free from the Microsoft website : https://visualstudio.microsoft.com/vs/community/

Once installed with the desktop .NET development module installed, clone this repository with `git clone https://github.com/SeleDreams/Betterloid.PluginTemplate.git` and start as an administrator the Setup.bat file included, when it requests the VOCALOID5 path, use the path where the Editor folder is located but don't include it to the path, for instance if VOCALOID5.exe is in "C:\Program Files\VOCALOID5\Editor" use "C:\Program Files\VOCALOID5\" in the Setup.

This will create a symlink allowing the project to locate the VOCALOID5 assemblies and to build the plugin in the right directory, you can now open the sln with Visual Studio and start working with it (make sure to use visual studio as an administrator to be able to compile properly without permission errors).

## Configuration

Every plugin has a configuration file that specifies the informations needed to load it, all plugins need unique names as they get loaded in the same domain, so make sure to give yours a unique name to not conflict with existing ones.

the PluginConfig.json has multiple variables to set:

- PluginActive

This setting like the name says define whether the plugin will be loaded or not, you can leave it as true as this is mostly targetting the end users.

- PluginAuthor

This setting is currently unused but will be used when Betterloid will have a menu, this contains the name of the plugin's author.

- PluginType

This setting defines whether your plugin runs as an Editor plugin or as a Startup plugin.

An Editor plugin will be added to the Betterloid Plugins tab and is more useful to do edit tasks similar to the VOCALOID4 JobPlugins, it will run as many times as the user selects the plugin in Plugins the tab.

A Startup plugin is a plugin that runs once when VOCALOID5 starts up, this is more useful to modify the general behaviour of the editor.

- PluginAssembly

This setting defines the name of your plugin assembly file, the DLL file that must be loaded by Betterloid to start your plugin.

- PluginName

This defines the name of your plugin as it appears in the VOCALOID5 Editor.

- PluginVersion

This defines the version of your plugin, currently unused.

- PluginNamespace

This defines the namespace of your plugin, keep it empty if you don't have a namespace

- PluginClass

This defines the class of your plugin, this is the class that will be instantiated. 

reminder : The class *needs* to inherit from IPlugin, else this won't work !