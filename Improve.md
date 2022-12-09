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
  - The Scene map is controlled by a tile grid system
    - Tilemap_Back is the ground layer which all other models stand on top of
    - Tilemap_Mid is on the enviroment layer which contains hitboxs that the player and npc collide with
  - Game Handler Scripts 
    - Main Camera 
      - Attacked to MainCamera object
      - Moves and stays focused on the player object  
    - GameManager 
      - Attached to the GameManager object
      - Starts the spawn rate for the enemies
      - Keeps track of points for the player through the Canvas and text
    - Conductor 
      - Attached to the Conductor object
      - Handles the music and the speed of the beat 
    - Rhythm Controller
      - Attached to the Rhythm object
      - Handles the Rhythm logic 
  - Player Character and Non-Player Character (NPC) Scripts
    - Player Controller 
      - Attached to Player object
      - Handles input from keyboard
      - Updates player model based on input from user
    - EnemyAI
      - Handles the pathing to track and move to the player 
      - Uses A star pahting algorithm to find the most optimal pathe to the player
    - Enemy Animations
      - This handles the animation of the enemies and is the master controller 
      - Is decoupled from EnemyAI so the visiuals and logic can function without each other  
    - Health
      - Handles all health logic for player and npcs  
  - Other Scripts
    -  Projectile Folder
      - Arrow Script
        - Handles the collision and the logic of the arrow
      - ShootProjectiles
        - Handler for whenever an object shoots a projectile
        - multiple scripts can subcribe to this class
      - MeleeAttacks
        - This script handles melee logic and collsions of all objects

## TODO
The following is a list of feature but did not have time for but can improve the project overall
- [ ] Add Character options
  - There was a plan to add at least one more character with a melee attack and a shield to block as a special
- [ ] Implement other enemies 
  - There was two other planned enemies
    - One is a mushroom character with a projectile attack
    - The other is a floating eye that explodes when close  
- [ ] Fix up death screen 
  - The transitions in the death screen need to be cleaned up. It doesn't work all the time
- [ ] Disconnect the animation from the player script
  - This would make it easier to add new models for the player and the logic for the player controller would be simplied 
