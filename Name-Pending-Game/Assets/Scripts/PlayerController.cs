using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = false;
    private float moveInput = 0f;
    private Vector2 velocity;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spi;

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

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spi = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime);

        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0 && isGrounded)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * playerSpeed, walkAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = velocity.y * jumpHeight;
        }
        else

        if (!isGrounded)
        {
            velocity += Physics2D.gravity * Time.deltaTime;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

    #region funny movement that doesn't really work like i want it to and i am very angry >:(
    /*
    private void Update()
    {

        if(moveInput == -1)
        {
            spi.flipX = true;
        }

        if (moveInput == 1)
        {
            spi.flipX = false;
        }

        if (isGrounded)
        {
            velocity.y = 0;

            
            if (Input.GetButtonDown("Vertical"))
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(0.625f, , 1);

            }
            

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }
        moveInput = Input.GetAxisRaw("Horizontal");
       
        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, playerSpeed * moveInput, walkAcceleration * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime);
        }
        
        velocity.y += Physics2D.gravity.y * gravityAmplify * Time.deltaTime;
        
        transform.Translate(velocity * Time.deltaTime);
        
        isGrounded = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }

            if (hit.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
    }
    */
    #endregion
