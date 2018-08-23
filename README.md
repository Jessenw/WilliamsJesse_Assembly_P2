# Assembly

Assembly is a top down resource management puzzle game that takes inspiration from games like Factorio and Frostpunk.

A demo video of Assembly can be found at: https://youtu.be/twFPM8HO-Bw

## Architecture
The game loop of Assembly begins with a train entering the players factory. The train has a list of requested components (only one item in the prototype). The player must create the requested components before the timer runs out. Components are created by building a factory that turns raw materials (copper, plastic, steel, rubber etc) into the requested components. In the prototype, this is done using two machines, the conveyor belt and the combiner. The conveyor belt is used to transport components and raw materials around the factory. The combiner takes raw components and turns them into new ones that the train may want. The objective of the game is to figure out what the train wants, and create those components using the combiner and conveyor belts. This loop repeats infinetly until the player loses by running out time.

## Setting up Assembly
Included in the submission is a .app for macOS and a .exe for Windows. Simply double clicking these should run the game.

## Instructions
Items can be placed using 'mouse1' and removed using 'mouse2'. Scolling the mouse wheel allows the player to change the currently equiped item. Clicking on a placed combiner will allow the player to select the combiner's recipe (Recipe's can be seen on the left side of the game).

## Challenges
By far the biggest challenge in assembly is the conveyor belts. The current implementation involves the belt itself moving any item that collides with it move towards an endpoint just past the end of the belt which allows the next placed belt to pick up the item. This works well enough, however it has several problems. Firstly, belts can get cluttered quickly and since each item is a rigidbody, it pushes the next item. For the prototype, the simple fix for this was to destroy any item that falls off the belt. Ideally, items would be able collide with each other without being able to push each other. I spent a decent amount of time trying to find a way to do this but it proved to be more difficult than first expected.
