using UnityEngine;

public class UpperGameAreaScript : MonoBehaviour
{
    private GameAreaCollider parentCollider;

    void Start() {
        // Assumes that the parent has the GameAreaCollider component.
        parentCollider = GetComponentInParent<GameAreaCollider>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        parentCollider.HandleTriggerEnter(collision);
    }
}
