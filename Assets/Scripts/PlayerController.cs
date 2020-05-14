using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Animator playerAnimator;
    private Rigidbody2D myRigidBody;

    private bool playerMoving;
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0.5f || horizontalInput < -0.5f)
        {
            myRigidBody.velocity = new Vector2(horizontalInput * moveSpeed, myRigidBody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(horizontalInput, 0f);
        }

        if (verticalInput > 0.5f || verticalInput < -0.5f)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, verticalInput * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, verticalInput);
        }

        if(horizontalInput == 0)
        {
            myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
        }
        if (verticalInput == 0)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
        }

        playerAnimator.SetFloat("MoveX", horizontalInput);
        playerAnimator.SetFloat("MoveY", verticalInput);
        playerAnimator.SetBool("PlayerMoving", playerMoving);
        playerAnimator.SetFloat("LastMoveX", lastMove.x);
        playerAnimator.SetFloat("LastMoveY", lastMove.y);
    }
}
