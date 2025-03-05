using UnityEngine;

public class GameAreaCollider : MonoBehaviour
{
    public LogicManager logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>(); // we need to do this at runtime because the object stil not exists
    }

    public void HandleTriggerEnter(Collider2D collision){ // On trigger exit and stay arre also available
        if (collision.gameObject.layer == (int)Utils.Objects.Bird){ 
            Debug.Log("scarso");
            logic.gameOver();
        }
    }
}
