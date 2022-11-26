# Quettatopia

![image](https://i.imgur.com/SSuZ5w4.png)

Polytopia-like civ game where the scale expands as you advance, from villages to nations to planets, with the full world map of the previous era becoming the city map of the next.

## Installation

The game is made in Godot Mono 3.4.4, which can be downloaded at https://godotengine.org/download/windows.

For C#, the .NET SDK is needed, which can be downloaded at https://dotnet.microsoft.com/en-us/download. 

Once Godot Mono and the .NET SDK are set up, the project can be imported into Godot by opening Godot, choosing "Import", and then importing the `project.godot`. Depending on how Mono was set up, Godot might not like building it straight away; if it gives a strange error like "build tools not found", check to make sure the .NET SDK in installed and otherwise in the Godot editor try Editor > Editor Settings > Mono > Builds and choosing a different build tool.