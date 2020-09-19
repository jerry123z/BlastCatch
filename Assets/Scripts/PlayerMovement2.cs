using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float rotSpeed = 120.0f;
    private Vector3 rotation;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal2") * rotSpeed * Time.deltaTime, 0);
 
        float move = Input.GetAxisRaw("Vertical2") * playerSpeed * Time.deltaTime;
        
        this.transform.Rotate(this.rotation);
        //move = this.transform.TransformDirection(move);
        
        if (move != 0)
        {
            controller.Move(transform.forward * move);
        }
    }
}
