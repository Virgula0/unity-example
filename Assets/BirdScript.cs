using System;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // apart from gameObject component, to access other components we need to create an access
    // to the component we wont to access.
    // So we create instance variable to access rigidbody2d component (the gravity component)

    // every field public here will be added in unity as field within the script component 
    public Rigidbody2D myRigidBody; // this MUST be public in order to be accessible from unity, we cannot rely on getters
    public float moveFloat; // this file will be useful for finding a good value for making the bird jump correctly and as smooth as possible. the smart thing is that we do not need to stop the game each time, but we can change the value in unity inspector and notice the chages immediately
    public LogicManager logic; // refers to our previous logic manager
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is for any code that runs as soon as the script is loaded.
    // So it is called once 
    void Start()
    {
        gameObject.name = "Bob Bird Renamed from the script";
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>(); // we need to do this at runtime because the object stil not exists
    }

    // Update is called once per frame
    // Every line of code fired up every single frame
    void Update()
    {
        // myRigidBody.velocity = 0;
        // For debugging purposes we cannot use Console.WriteLine we have to use Debug unity 
        // library Debug.Log(myRigidBody.velocity);
        // myRigidBody.linearVelocity = Vector2.up * 10; //  we move to y axis the bird (so vertically)
        
        // difference between getkeydown and getkeyup is that the first behavios in pressure
        // the latter is appplied when the key is released
        myRigidBody.linearVelocity = Input.GetKeyDown(KeyCode.Space) && this.birdIsAlive ? Vector2.up * this.moveFloat : myRigidBody.linearVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision){ // On trigger exit and stay arre also available
        if (collision.gameObject.layer == 3){ // 3 stands for the bird we want actually check that is the bird object to pass through the pipe
            logic.gameOver();
        }
    }
}
