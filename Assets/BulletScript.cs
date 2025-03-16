using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float bulletLife = 1f;

    private float LIMIT = 23.02f;

    public float speed;

    private Vector2 spawnPoint;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= LIMIT){
            Destroy(this.gameObject);
        }else{
            timer += Time.deltaTime;
            transform.position = Movement(timer);
        }
    }

    private Vector3 Movement(float timer){
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector3(x + spawnPoint.x, y + spawnPoint.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == (int)Utils.Objects.Pipe)
        {
            Debug.Log("BULLET DESTROYED");
            Destroy(this.gameObject);
        }
    }
}
