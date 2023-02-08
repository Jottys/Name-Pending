using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    #region Speeds
    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float walkAcceleration = 15f;
    [SerializeField]
    private float airAcceleration = 3f;
    [SerializeField]
    private float groundDeceleration = 10f;
    [SerializeField]
    private float jumpHeight = 5f;
    [SerializeField]
    private float gravityAmplify = 3f;
    #endregion


    private void Update()
    {
        transform.Translate(playerVelocity * Time.deltaTime);
        Raycast();
        if (!isGrounded)
        {
            playerVelocity += Physics2D.gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
        }

        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            playerVelocity.x = Mathf.MoveTowards(playerVelocity.x, moveInput * playerSpeed, walkAcceleration * Time.deltaTime);
        }
        else
        {
            playerVelocity.x = Mathf.MoveTowards(playerVelocity.x, 0, groundDeceleration * Time.deltaTime);
        }


    }

    private bool isGrounded;

    private Vector2 playerVelocity;

    void Raycast()
    {
        RaycastHit2D downHit;
        RaycastHit2D rightHit;

        for (int i = -1; i < 2; i++)
        {
            Debug.DrawRay(transform.position + (Vector3.right * 0.5f * i), Vector2.down * 100, Color.red);
            if (downHit = Physics2D.Raycast(transform.position + (Vector3.right * 0.5f * i), Vector2.down))
            {
                if (downHit.distance > 1f)
                {
                    isGrounded = false;
                }
                else if (downHit.transform.tag == "Ground")
                {
                    isGrounded = true;
                    playerVelocity.y = 0;
                }
            }
        }

        for (int i = -1; i < 2; i++)
        {
            Debug.DrawRay(transform.position + (Vector3.up * 0.5f * i), Vector2.right * 100, Color.red);
            if (rightHit = Physics2D.Raycast(transform.position + (Vector3.up * 0.5f * i), Vector2.right * 100))
            {
                if (rightHit.distance > 0.5f)
                {
                    playerVelocity.x -= playerVelocity.x;
                }
            }
        }
    }
}
