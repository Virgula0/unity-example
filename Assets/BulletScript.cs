using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;

    public float bulletLife = 1f;

    [SerializeField]
    private float bulletRotation = 0f;

    public float speed = 1f;

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
        if (timer > bulletLife){
            Destroy(this.gameObject);
        }else{
            timer += Time.deltaTime;
            transform.position = Movement(timer);
        }
    }

    private Vector2 Movement(float timer){
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == (int)Utils.Objects.Pipe)
        {
            Debug.Log("BULLET DESTROYED");
            Destroy(this.gameObject);
        }
    }
}
