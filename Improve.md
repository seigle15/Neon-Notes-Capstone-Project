# Current Build and Improvements
Hi, this is a technical break down of how the program works, where resources are located, and how to improve apon it.

## Coded in C#
For those who are more familiar with Java or C/C++, C# is not too different and will most likely find it easy to understand. There are also several resources on how to write software for Unity in the forms of youtube videos and documentation, found [here](https://docs.unity.com/). 

## Development Enviroment
For future dolphins working on this project, Here is a break down of the tools used in the current build and how to acess them.

Most importantly is having acess to Unity Platorm 
- Current Version is 2021.3.10
- Link [here](https://unity.com/download) for how to download 

This project was made using Jet Brains Rider IDE. Here are the main draws to using Rider:
- It's free to sign up and download if you are a college student or professor. 
  - linking your college email to get access to all of Jet Brains software development tools
- Rider has plugins that link to Unity and Github
  - These plugins saved lots of time linking a pushing to this repository 
  - The only downside is that only the code is pushed through the plugin, you would still need to use GitBash or GitUI

## How The Game Works
All important folders for how the program operates is located in the Assets folder. Recommend opening that up during the explaination. There is a lot going on but breaking it down into each Scene, in the Scene folder, then describing how each is managed will help. 

1. Opening Scene
  - Controls the difficultly settings and which music will be passed into the next Scene, Gameplay_Scene.
  - The Canvas is the main aspect show to the user and has three buttons for the settings
  - MainMenu Script 
    - Which controls the the settings 
    - Depending on the selected setting from the buttons
  - MusicManager Script 
    - Recieves Selected difficulty and Music from MainMenu
    - Is a Singleton that can be acessed through an instance valariable in the other Scenes 
  
2. Gameplay_Scene
  - Game Management  
    - GameManager Script
      -  Starts the spawn rate for the enemies
      -  Keeps track of points for the player through the Canvas and text
    - Conductor Script
      -   sdfsjk;g
    - Rhythm Controller
      -  Handles the Rhythm logic 
   

