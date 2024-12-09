Requirements for running the game:
1.	Download Unity >= 2022.3.20f1
2.	Clone or download the project
3.	A computer with a keyboard is needed for playing the game


Overview of the game:

The game gets its inspiration from the Nintendo game New Super Mario Bros. While also being inspired by the classic Mario games that have been and is currently quite popular. The game is a platforming game, but a key distinction between this and the original game is that this new game is made to be a 3D version. This adds a new dimention to the game giving more depth, even though it is still a but worse version of the game. 

The primary goal of the game is to navigate through the level and avoid getting killed by enemies or falling into the dangerous water. During the level, players will try to collect as many coins as possible, as they are scattered throughout the path through the level. They enable the playerto reach the highest possible score before they reach the end of the level.
Killing enemies also gives the player points , so killing as may as possible in the level makes the players score reach even higher.

Main Game Elements:

•	Player – It is a boy who can be controlled by using either AWSD or the arrow keys for movement. The player can also jump to avoid obstacles by using the spacebar.

•	Camera – The game has a camera that follows behind the player as he moves through the world.

•	Enemies – Little ghosts scattered around the world. They are the ones who try to kill the player for an additional challenge. The player must in turn kill these ghosts in order to get more points. They are each worth 5 points when they are killed.

•	Coins – These can be found throughout the world. When the player collects these coins, they are gathering more points for their final score. Each coin is worth 1 point.

•	Finish flagpole – At the end of the level is a flagpole. Reaching it both indicates the end of the level but it also gives the player 10 additional points before they finish the game.

•	Water – Water is dangerous in this version of Mario as when the player is falling down into water they will immediately die. Hereafter they will get the opportunity to restart the game and give it another try. 

Project Parts:

•	Scripts

&nbsp;o	PlayerMovement - Handles player movement with keyboard inputs. Enables jump with coyote jump for a smoother jump experience.

&nbsp;o	PlayerTracker – Is used to track the player’s movement in the world, to enable the camera to follow.

&nbsp;o	pointSystem – Manages the player’s score collected from the coins, killing. enemies and finishing the game. As well as updates the UI to display the score.

&nbsp;o	PlayerHealth – Tracks the damage dealt to the player and whether they are dead or alive. Implements a UI screen showcasing the score and enables the player to restart the game.

&nbsp;o	Follow – Makes Enemies follow the player when they are within a close proximity to them. It also enables the player to kill the enemy by jumping on top of it or take damage by regular collision if the player can not jump on the enemy in time. As well as give points when an enemy Is killed.

&nbsp;o	DamageObject – This gets attached to the water game objects in order to deal damage when theres is a collision betwwn the water and the player.

&nbsp;o	EndGame – When activated this script displays the replay screen upon collision with the finish line.

&nbsp;o	SceneLoader – When the UI replay screen is visible, this script allows you to pressthe replay button in the UI screen which in turn reloads the game.

•	Assets

&nbsp;o	Platformer Assets: https://assetstore.unity.com/packages/3d/environments/gamedev-starter-kit-platformer-free-edition-240260

&nbsp;o	Unity GameObjects used to create poles or flagpoles

•	Materials

&nbsp;o	Basic unity materials for solid-colored objects such as the Unity GameObjects

&nbsp;o	Materials included in the Platformer Assets: https://assetstore.unity.com/packages/3d/environments/gamedev-starter-kit-platformer-free-edition-240260

•	Scenes

&nbsp;o	There is only one scene in the game. Which encompasses the one playable level as well as the UI screen


| **Task**                      | **Time (hours)** |
|-------------------------------|------------------|
| Unity setup & making GitHub   | 0.5              |
| Game idea and gray boxing     | 2                |
| Player movement and testing   | 1.5              |
| Camera movement script        | 1                |
| Finding platformer assets     | 0.5              |
| Scoring system                | 1.5              |
| Enemy implementation          | 2                |
| Final design                  | 2                |
| End game with UI elements     | 1.5              |
| Play testing & bug fixes      | 2                |
| Make README                   | 0.5              |
| **Overall time**              | **15 Hours**     |


References Used for project: 

•	Controlling Unity camera: https://learn.unity.com/tutorial/controlling-unity-camera-behaviour#5fc3f6a3edbc2a459f91c6af

•	Coin Collection system: https://www.youtube.com/watch?v=6iSJ_jh6Rdo 
