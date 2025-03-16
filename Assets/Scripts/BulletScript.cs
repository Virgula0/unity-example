using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float DESTROY_X_AXIS;
    private GunScript gunScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gunScript = GameObject.FindGameObjectWithTag("FirstGun").GetComponent<GunScript>(); // Find gun prefab by tag

        if (!this.gunScript){
            throw new ArgumentNullException("gun script should not be null");
        }

        this.DESTROY_X_AXIS = gunScript.getPipeSpawner().transform.position.x; // for some reason pipeSpawner object cannot be attached to Bullet Prefab
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > DESTROY_X_AXIS){
            Destroy(this.gameObject);
        } else {
            transform.position = MoveBullet();
        }
    }

    private Vector3 MoveBullet(){
        return transform.position + Vector3.right * this.gunScript.getSpeed() * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == (int)Utils.Objects.Pipe)
        {
            Debug.Log("BULLET DESTROYED BY PIPE");
            Destroy(this.gameObject);
        }
    }
}
