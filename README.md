# Udemy-Csharp-Unity-Game-Development  
Udemy course for learning game development with C# and Unity. I'm using this to take some notes and keep track of my design ideas, etc.  
  
Key Points to Remember:  
  
Have some sort of an image whether it's on the computer or hand sketched so we have an idea of what we're building.  
  
Make a note of and keep in mind:  
	* Player Experience - What should the player feel, e.g. nimble/agile (Helps make decisions while building the game)  
	* Core Mechanic - e.g. Move and dodge obstacles  
	* Game Loop - e.g. Get from A to B without hitting obstacles  
  
Games:  
  
1. Bricky Road - Obstacle Course  
  
Character Name: Bricky  
Player Experience: Nimble/Agile  
Core Mechanic: Move and dodge obstacles  
Game Loop: Get from A to B without hitting obstacles  
  
  
2. Ship Shapes - "2D" Spaceship Obstacle Course   
  
Character Name: Ricky the Rocket  
Player Experience: Precision/Skillfull  
Core Mechanic: Skillfully fly spaceship and avoid environmental hazards  
Game Loop: Get from A to B to beat a level, progress levels to beat the game. If the player dies on any level they restart that level. Currently the player has infinite lives.  
  
Theme:  
Ricky is a prototype AI spacecraft exploring the depths of an unknown planet. His mission was to report on the condition of the planet but he went too deep and now the transmission can't break through and he has to try to escape. It almost seems like the environment itself is animated with a malevolent desire to keep Ricky from escaping! It's as if the planet itself lulled Ricky into a false sense of safety to get him to go too deep. Now, the closer Rickey gets to escaping the harder the planet tries to keep him.  
  
Onion Design:  
Core Feature: Moving from A to B  
2nd Feature: Dying and resetting the level when we hit an obstacle  
3rd Feature: Moving to the next level when we get to B  
4th: Break free from the planet. Win the game   
5th: Moving obstacles  
6th: Obstacles that chase Ricky  
7th: Paralax background  
8th: Ricky can shoot!  
9th: Powerups   
  
  
3. Starship Coyote - Rail Shooter   
  
Character Name: Yote McRain  
Player Experience: Chaos  
Core Mechanic: Dodge and shoot  
Game Loop: Get as far as possible without dying to beat the high score, infinite runner style. Player starts over from 0 at death.  
  
Theme: Yote is an ace pilot who loves to do barrel rolls. Undetermined if barrel rolls will actually be in the game. Yote must fight through hordes of attacking aliens in an effort to protect his home world.  
  
Planned Features  
Camera Rail - Camera follows a path through the level  
Player Movement - WASD to move horizontally and vertically  
Shooting - Player shoots bullets which do damage to enemies  
Health - Enemies have health that is reduced when the player shoots them  
Enemy Paths - Enemies should travel on paths that are hand placed by the designer  
Score - Points accumulated for destroying enemies  
Game Loop - Player restarts the level upon death  

Potential Features
Multiple levels - Load the next level when completing a level  
Player Shield - Shield that is depleted when enemies hit the player, recharges over time when not being hit  
Pickups - Instant shield recovery, faster firing rate, more projectiles, etc.  
Momentary Invulnerability - After taking damage the player is invincible for a short period  


4. Realm Rush - Tower Defense   
  
Character Name: The Grand Stratis
Player Experience: Tactical / Strategic  
Core Mechanic: The player has limited resources and must  
 strategically place defenses to stop enemies   
Game Loop: Survive against waves of enemies as long as possible  
	The level reloads if the player runs out of gold  
  
Theme: 
Defend against attackers who want to steal all of your gold!   
  
Art:  
Medieval Fantasy Voxel Art   


Planned Features:  
Enemies Pathfinding 
Defensive Towers 
Resource Management  


Potential Features:  
Dynamic Enemy Pathfinding  
Build Timer for Towers




