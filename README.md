# Zombie Graveyard - Unity Game

## Game Features


Zombie Graveyard is an intense and thrilling 3D game set in a dark and eerie graveyard filled with hordes of zombies. 

* As the player, your objective is to survive as long as possible by eliminating the zombies using various weapons and avoiding damage. Teleportation mechanics, a dynamic minimap, and an immersive score system make the game both challenging and engaging.


* Intense Zombie Combat: Battle waves of zombies with different weapons and mechanics.


* Teleportation Mechanics: Automatically teleport to a safe location when severely injured.


* Dynamic Minimap: Track your position in the graveyard with a 2D minimap.


* Score System: Earn points for every zombie killed and see your final score when the game ends.


* Enemy AI: Zombies patrol the graveyard and engage the player when within range.


* Player Lives Display: Visual feedback on the player's remaining lives.


* Interactive Environment: Destructible objects that enhance the gameplay experience.


## How to Play


Objective: Survive by killing as many zombies as possible.


## Controls:


Movement: Use WASD or arrow keys to move.


Attack: Click the left mouse button to shoot.


Teleportation: Automatic when health reaches critical levels.


Minimap: View your position relative to the graveyard.


## Gameplay:


Navigate the graveyard and eliminate zombies.


Watch your health and prepare for automatic teleportation when necessary.


Collect ammo pickups to stay in the fight.


## Scripts Overview

1. Ammo Management (Ammo and AmmoPickup):
The Ammo script manages the player's ammunition, providing methods to get, increase, and decrease the ammo count. The AmmoPickup script handles ammo collection when the player collides with an ammo pickup.
Suggestions:

Consider adding some validation in ReduceCurrentAmmo to prevent ammo from going negative.
You might also want to add a check in IncreaseCurrentAmmo to limit ammo to a maximum value.
2. Player Health and Teleportation (PlayerHealth):
The player’s health is managed in the PlayerHealth script, which also triggers teleportation when health drops to certain thresholds (200 and 100). The teleport script manages the teleportation process.
Suggestions:

Consider adding visual or audio feedback when teleportation occurs to make it more noticeable to the player.
If the teleportation mechanic is crucial, you might want to log or display the current health to give players feedback about when they might be teleported.
3. Enemy AI and Behavior (EnemyAI, EnemyAttack, EnemyHealth, PatrolScript):
The enemy AI chases and attacks the player based on distance, health, and whether it’s provoked. Patrol behavior is disabled when the enemy is provoked.
Suggestions:

The EnemyAttack script could include more complex behaviors, such as different attack patterns based on player distance or enemy health.
Adding a cooldown between attacks could make the AI less predictable.
4. UI and Scene Management (DeathHandler, SceneLoader, MenuScript, WelcomeScript):
UI elements such as game over screens, score displays, and fade effects are managed in these scripts.
Suggestions:

Ensure all UI elements, like hellText in WelcomeScript, are correctly initialized and not null to avoid runtime errors.
The WelcomeScript includes commented-out code for a timer. If you plan to implement a countdown, it could be useful for creating a sense of urgency or a time-based challenge.
5. Weapon Handling (Weapon, WeaponSwitcher, WeaponZoom):
The weapon handling covers shooting, switching between weapons, and zooming for aiming. Ammo is reduced on each shot, and sound effects are played.
Suggestions:

The Weapon script is set up to play audio when shooting, but you may want to handle cases where the AudioSource is missing.
The zoom feature in WeaponZoom toggles between zoomed in and out states. Consider adding a smooth transition between these states to make the experience more immersive.
6. Score Management (ScoreManager):
A static class is used to manage the player's score, with methods to add, get, and reset the score.
Suggestions:

You may want to save the score to PlayerPrefs or another persistent storage method to keep the score between sessions if necessary.
7. Debugging and Logs:
There are several debug logs in place, which can be helpful during development. Remember to remove or comment out these logs for the final release or use conditional compilation to include them only in development builds.
Let me know if you need further guidance or if there's anything else you'd like to discuss!
