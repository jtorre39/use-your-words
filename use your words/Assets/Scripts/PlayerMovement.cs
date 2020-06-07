using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocityXDefault;
    public float velocityYDefault;

    Rigidbody2D rbd2D;
    Vector2 velocityOnPreviousFrame;

    // Start is called before the first frame update
    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        velocityOnPreviousFrame = new Vector2(rbd2D.velocity.x, rbd2D.velocity.y);

        if (horizontalAxis != 0)
        {
            rbd2D.velocity = new Vector2(velocityXDefault * horizontalAxis, rbd2D.velocity.y);
        }

        var newLocalScaleX = velocityOnPreviousFrame.x > 0 && rbd2D.velocity.x < 0 ?
            transform.localScale.x * -1 : velocityOnPreviousFrame.x < 0 && rbd2D.velocity.x > 0 ?
            transform.localScale.x * -1 : transform.localScale.x;

        transform.localScale = new Vector3(newLocalScaleX, transform.localScale.y, transform.localScale.z);
    }
}
