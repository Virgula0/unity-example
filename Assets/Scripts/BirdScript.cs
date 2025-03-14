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

    [SerializeField] // we do not break visibility and we let this to be available in unity inspector
    private AudioSource wingFlaps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is for any code that runs as soon as the script is loaded.
    // So it is called once 
    void Start()
    {
        this.gameObject.name = "Bob Bird Renamed from the script";
        this.myRigidBody.gravityScale = 5;
        this.logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>(); // we need to do this at runtime because the object stil not exists
        this.logic.setBirdInstance(this);
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
        if (Input.GetKeyDown(KeyCode.Space) && this.birdIsAlive) {
            wingFlaps.Play();
            myRigidBody.linearVelocity = Vector2.up * this.moveFloat;
        }
    }

    // for some reason these methods do not need to be public, Start and Update are private as well without keyword
    // explicitly declared
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Utils.Objects.Pipe)
        {
            Debug.Log("collided!");
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}
