using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterM : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSpeed = 5f;
    public float jumpForce = 10f;

    Rigidbody body;
    float horizontal;
    float vertical;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true; // Disable rotation due to physics.
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        CheckIfGrounded();

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Character is no longer grounded.
        }
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 direction = forward * vertical + right * horizontal;

        Vector3 movement = transform.position + direction.normalized * Time.fixedDeltaTime * movementSpeed;

        body.MovePosition(movement);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void CheckIfGrounded()
    {
        float rayDistance = 1.1f; // Adjust this value based on your character's size.
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayDistance);
    }
}

