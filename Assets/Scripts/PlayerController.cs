using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator playerAnimator;

    private bool playerMoving;
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0.5f || horizontalInput < -0.5f)
        {
            transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(horizontalInput, 0f);
        }

        if (verticalInput > 0.5f || verticalInput < -0.5f)
        {
            transform.Translate(new Vector3(0f, verticalInput * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, verticalInput);
        }

        playerAnimator.SetFloat("MoveX", horizontalInput);
        playerAnimator.SetFloat("MoveY", verticalInput);
        playerAnimator.SetBool("PlayerMoving", playerMoving);
        playerAnimator.SetFloat("LastMoveX", lastMove.x);
        playerAnimator.SetFloat("LastMoveY", lastMove.y);
    }
}
