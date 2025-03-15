using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 3f;
    public float speed = 20f;

    [Header("Spawner Attributes")]
    [SerializeField]
    private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            shooting();
            timer = 0;
        }
    }

    private void shooting(){
        Debug.Log("BAM!");
        if(bullet){
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletScript>().speed = speed;
            spawnedBullet.GetComponent<BulletScript>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
