using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Bullet Attributes")]
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float speed = 20f;

    [Header("Spawner Attributes")]
    [SerializeField]
    private float firingRate = 1f; //TODO: implement logic for firing rate

    [SerializeField]
    private GameObject pipeSpawner;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            shoot();
        }
    }

    public GameObject getPipeSpawner(){
        return this.pipeSpawner;
    }


    public float getSpeed (){
        return this.speed;
    }
    
    private void shoot(){
        Debug.Log("BAM!");
        if(this.bullet){
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
