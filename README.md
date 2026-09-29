# Lab1_GEDAI_AK

Name: Ashley Klahm
Student Number: 100963908

Project title: Bubble Floaty McGee
Description:
This game was a solo project made for the Global Game Jam 2025. It is a very simple platformer where you play as this silly bubble girl named 
Bubble Floaty McGee and have to rid the world of evil bubbles by collecting them.
The gameplay loop is: Explore level -> Collect bubbles -> Progress to new level

Flowchart explaining your use of the Singleton Design Pattern:
<img width="652" height="478" alt="Screenshot 2026-09-29 175710" src="https://github.com/user-attachments/assets/92cb218c-d8d7-4000-84fd-0f16c1dbcaf7" />

Answers to the following reflection questions:
What element of your game adopts the chosen pattern?
I decided to implement a singleton as my Scene Manager. This is an old Game Jam game so i felt there was a lot of places where coding could be improved/cleaned up. The Scene Manager has a function to check which scene is active and switch it to the next one accordingly. An Instance of this is called in the Player Controller once the player has collected all bubbles within the scene. 

Why is this pattern a good choice for the associated functionality?
This pattern is a good choice for functionality because of the amount of scenes this game has and for cleaning up code. All together this game has 5 different scenes that rely on collecting bubbles to change them. If the Scene manager has more than one present in a scene it could create errors or unnecessary lag with multiple scripts running to do the same thing. I think practices wise making a Scene manager cleans the code up a lot better than having it originally all in the Player Controller (see screenshot below). I think the Scene Manager is valuable if I wanted to make more additions to the game like being able to go back to certain levels or if I was too add additional scenes or levels to the game.

<img width="564" height="581" alt="Screenshot 2026-09-29 155746" src="https://github.com/user-attachments/assets/e7cc3e6b-d2cc-4fab-9c4b-fe612ce0fcc1" />
<img width="601" height="340" alt="Screenshot 2026-09-29 155810" src="https://github.com/user-attachments/assets/0ec84b56-2011-4be0-8c1a-41bc07dfc99c" />

