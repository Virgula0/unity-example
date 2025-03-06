using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicManager logic; // refers to our previous logic manager
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicTag").GetComponent<LogicManager>(); // we need to do this at runtime because the object stil not exists
    }

    private void OnTriggerEnter2D(Collider2D collision){ // On trigger exit and stay arre also available
        if (collision.gameObject.layer == (int)Utils.Objects.Bird){ // 3 stands for the bird we want actually check that is the bird object to pass through the pipe
            logic.addScore(1);
        }
    }
}
