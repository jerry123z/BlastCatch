using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public Rigidbody rb;
    public float movementForce = 20f;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool moveUp = false;
    private bool moveDown = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveLeft = Input.GetKey("a");
        moveRight = Input.GetKey("d");
        moveUp = Input.GetKey("w");
        moveDown = Input.GetKey("s");
    }

    void FixedUpdate()
    {
        if (moveLeft)
        {
            rb.AddForce(0, 0, movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (moveRight)
        {
            rb.AddForce(0, 0, -movementForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (moveUp)
        {
            rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (moveDown)
        {
            rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
