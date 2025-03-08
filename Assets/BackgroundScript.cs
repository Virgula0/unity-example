using UnityEngine;

/*
    This is to operate on images within a canvas.
    At the moment this script is only for learning pruposes and it is not used.
    Instead, we used material with mesh to create a real background feeling.
*/

public class BackgroundScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 startPosition;
    private RectTransform rectTransform;
    private float repeatWidth; // manually should be 38.5f

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = transform.position;
        // Calculate the distance from pivot to the right edge of the image
        // lossyScale is the the global scale of the object
        repeatWidth = rectTransform.rect.width * rectTransform.lossyScale.x * (1 - rectTransform.pivot.x);
    }

    void Update()
    {
        // Move the image to the left
        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        // Check if the image's right edge has passed the original starting point
        if (transform.position.x <= startPosition.x - repeatWidth)
        {
            // Reset to the start position for seamless looping
            // Instead of resetting exactly to startPosition,
            // add the repeatWidth to account for any overshoot.
            Debug.Log("Background resetted");
            transform.position += new Vector3(repeatWidth, 0, 0);
        }
    }
}