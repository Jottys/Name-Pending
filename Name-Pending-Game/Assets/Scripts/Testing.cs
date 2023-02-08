using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Vector2 velocity;
    private bool isGrounded;


    // Update is called once per frame
    void Update()
    {

        transform.Translate(velocity * Time.deltaTime);
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 5 * moveInput, 5 * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, 5 * Time.deltaTime);
        }


        
        if (!isGrounded)
        {
            velocity += Physics2D.gravity * Time.deltaTime;
            //transform.Translate(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = 0;
            
        }
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("aaa");

        }
        else
        {
            isGrounded = false;
        }
    }
}
