# RollABall
Roll a Ball game built with unity, World Mods
Itch.io (Link to run game)
https://db488.itch.io/rollaballwithmods
World Mods:
1. Wall Textures – The first Modification I made was to the walls. In order to have the 
texture fit correctly, I made a bunch of walls. The main box that we created in the demo 
was using only 4 walls, one for each side. To get the textures to Line up I added 4 walls 
to each side, and that made the textures appear in a nicer format. I later found out that 
there is a much easier way to do this.
2. Ground Textures – I added a dirt texture to the ground to fit with the look since I wasn’t 
sure how to not have the texture stretch to fit the entire area. I still want to figure out 
how to have the pattern repeat to fill rather than stretch to fill.
3. Pickup 1 (Enemy) – I wanted to play with importing models, so I decided to just grab the 
first model which ended up being a Yeti doing a T-Pose. I added their texture as well, 
and it is surprising how the texture maps onto a sphere, but when applied to the model, 
everything fits. I did notice an issue with their “hitbox” and this is something I want to 
explore more in the future.
4. Pickup 2 (Health Pack) – I did this similarly to the Yetis as mentioned above, but here I 
wanted to work with adding more than one pickup and having them each do something 
specific (See code mods). 
5. Skybox – This is something I hadn’t thought about adding but again, it was something 
that I wanted to play with and learn more about. I tried to get all the corners of the box to 
line up and failed. It might have been something with the model I found online but it was 
still something fun to mess with and add to my tool belt. 
6. Second ‘level’ – I wanted to add something to add more than just collecting X items and 
having the game end so I decided to create another plane and add more walls around it to 
create a second play area.
7. Secondary Light sources – With the skybox and second floor added, it was noticeably 
darker with one light source. I initially tried to just add a second light source from under 
the first floor, but it just did not look right. I then played around with more light sources 
(See world mod #7).
8. Lamps – Since I needed something to contain the second light sources, I decided to add 
streetlights (Lanterns really). These are symmetrical around the map and every other one 
has a source of dim light. This is just enough to light up the play area for the user to see 
what is happening in their world.
9. Health – I changed the Score that counted pickups from 0 – 12 to a health monitor. It 
counts down from 100 and decreases by 10 for each Yeti you interact with. The health 
packs do add enough health to finish the level, but you must collect at least one otherwise 
you will die. 
10. Spotlight – I added a red spotlight to the health packs to have them stand out more in the 
dark. Unfortunately they spin and rotate with the health pack, but it does make sense 
that they behave like this. 
Code Mods: 
1. Player Speed Decrease - The most obvious modification I made was to the player speed. 
I have the player accelerate slower each time they defeat an enemy. This is so their 
health plays an effect on their interactions with the game. This was done by using the 
original method for updating the count that was used in the tutorial. But as it changes 
their health instead of count, it also decreases their speed factor. 
2. Walls Dropping – Once the player defeats all the enemies on the top level, they can move 
onto the next part, on a lower level. Instead of creating a long ramp I just let the player 
fall. This was done by checking the number of enemies that were killed and then once a 
certain number was reached (5) the walls would be set to inactive. 
3. Object Arrays – I used an array to hold both the wall objects that were to be ‘Dropped’ as 
in Modification #2. Initially I used GameObject.FindGameObjectWithTag() but this 
would only return at most 1 object. 
4. Audio – I did not want too much audio in this demo, but I added an audio clip for when 
the player picks up a Health Kit. This was also mostly done in the method for pickups 
that were in the tutorial, but it had to check that the tag on the Heath kit was the right one 
before playing its audio. 
5. “Pickup” Tags – Expanding off of Modification 3, there were two different types of 
pickups for the player to interact with. This was done by using two different tags for the 
objects. The code within the playerControler Script relied on comparing the two tags to 
determine what each pickup will do.
6. Player Health – Adding health meant that needed to be a way to lose the game. If the 
players health drops below 0, then the game is over. It is hard to lose, but possible. This 
was something that was checked at the of the OnTriggerEnter method. 
7. Rotations – Both the health pack and enemies share the same Rotator script, but this was 
changed to only rotate in the horizontal direction, making everything spin on one plane. 
8. Win Condition – I changed the if statement of winning within the PlayerControler Script. 
This changed from 12 to 10, but also needed to check that the player still had enough 
health since the player can die after hitting all 10 enemies without picking up a Health 
Pack. 
9. Objects Appear – On the first platform there is a health pack that is initially active. Once 
the PlayerControler Script holds onto that object, it causes it to disappear. This is so it can 
pop-up once all the enemies are defeated on the top level. The re-appearing is done by a 
check on the number of enemies killed.
10. End Of Game Message – I altered the “win text” that was used in the tutorial to display 
another message instead. I also added a method to display when the player dies.
Game Mechanics:
The most important game mechanic included was physics. Almost every interactive object in my 
game uses physics, and it is the main way that the player is able to move around the map. The 
next mechanic is in the internal economy. This is done through a major resource: The Player’s 
Health. This also relates directly to the player’s physics by increasing/decreasing acceleration 
based on the player’s health. This Game also uses progression mechanics. In order to move 
onto the lower level in the game, the player must defeat all the enemies on the first level. There 
is a low level implementation of tactical maneuvering included in this game. Without collecting 
at least one health pack, it is impossible to win. Each enemy decreases your health by 10 and 
there are 10 enemies, so picking up at least one health pack is critical. There is no social 
interaction included in this game.
