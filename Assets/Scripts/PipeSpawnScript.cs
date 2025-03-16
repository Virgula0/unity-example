using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 3; // how much it should pass to spawn the next pipe
    private float timer = 0;
    public float highOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SpawnFunction(); // we do this at startup of the script in order to make the first pipe to spawn soon without waiting a lot of time before the first
    }

    private Vector3 RandomPosition(){
        float lowestPoint = transform.position.y - highOffset;
        float highestPoint = transform.position.y + highOffset;

        return new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);
    }

    private void SpawnFunction(){
            // spawn the object 
            // we use (T original, Vector3 position, Quaternion rotation) 

            // since with this instance simple code Instantiate(pipe, transform.position, transform.rotation); the object 
            // spawns at every frame we create a lot of copies of the pipe but it is not correct actually
            // to make this to work we need to use a timer whcih runs the code after each N time

            // we change also the current transform position to a random value
            Instantiate(pipe, RandomPosition(), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            // count the time
            timer += Time.deltaTime; // time.deltatime assure that behavios the same no metter which computer is running on
        }else{
            SpawnFunction();
            timer = 0; // reset the timer
        }
    }
}
