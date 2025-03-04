using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5;
    public float deadZone = -45; // the zone dead out where pipes can be delated beacuse are out of the screen already 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < deadZone){
            Debug.Log("Pipe Deleted");
            Destroy(gameObject); // destroy the game object that holds the script
        }

        // we can access transofrm properties directly without instancing variable
        // transform position can be casted to Vector2 eventually 
        // Time.deltatime -> The interval in seconds from the last frame to the current one
        // we multiple our position to that value in order to match correct FPS on the current machine
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    }
}
