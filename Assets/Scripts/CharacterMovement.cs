using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private LayerMask ground = 0;
    [SerializeField] private Transform footPosition = null;
    [SerializeField] private bool isJump = false;

    private void Update()
    {
        if(Physics2D.OverlapCircle(footPosition.position, 0.2f, ground))
            isJump = true;

        if (Input.GetKeyDown(KeyCode.Space)) 
            Jump();
    }

    private void FixedUpdate()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 movement = new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.deltaTime;

        
        transform.Translate(movement);
    }

    private void Jump()
    {
        if (isJump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
            isJump = false;
        }

    }
}
