# Game Object 

Container that as a position a rotation and a scale. You can fill game object with components to add extra features.

The bird the pipes user interface and cameras are game objects.

Sprite render is a component.

Add gravity to the bird component by adding a component called `rigidbody2d` within physics 2d section.

We also wnat the bird to interact with other objects called `circle callider 2d`, this is the hitbox of the object.

Now we have to add behaviour component (C# script). this will be a custom component for adding behavior to the object.

Once created the instance variable for RigidBody2d we will find the reference in unity in the component within the inspector section.
Then you can drag and drop the rigidbody2d component in MyRigidBody in BirdScript component. In this way we enstablish a line of communication between the script and 
rigidbody.

Now want we wont do to is that the bord is completely stucked and the pipes move across the screen so it seems that the bird is moving.

We create pipe and a child object called top pipe in order to create more object that moves along the screen following the parent.

We do a duplicate of top pipe, we flip the bottom up and then we add ascript to Pipe parent compoentne called `PipeMoveScript`

Prefabricated Game oBject: move pipe game object in to assets in unity (prefab).

This is like a blueprint for a gaming object. we can create new instances of the same game objects multiple times.
Then we can remove (delete) the game object from SampleScenes because otherwise we should modified not only the prefabs but also the original game object.
For this reason we delete it.

We can create a new game object called game spwaner. We put it to the right of the camera. We than create a new script component for the pipe spawner and the
purpose is to spawn new versions of the pipe prefab every few seconds.

We create a gameobject field called pipe within the script and then we drag and drop the pipe prefab from assets to the pipe script field in unity.

After imolementing the script for this what we have to do is to create a score for user interface.

This time in samplescene instead of creating a normal game object, right click -> ui -> legacy -> text

We need to add collision after adding the function for incrementing the user score and import it in unity.

Now to achieve collisions we must implement colliders.

We add this to the pipe prefab, double click on the pipe.

We tick the box on box collider of middle pipe to `is trigger -> true`

For Try again button we set onClick event.

