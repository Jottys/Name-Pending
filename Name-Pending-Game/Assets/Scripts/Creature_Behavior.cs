using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_Behavior : MonoBehaviour
{
    public GameObject groundRay;
    Rigidbody2D rb2d;
    private float Horizontal = -1;
    public float speed;
    private bool facingRight = true;
    Vector2 characterDirection;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;

    private float timeRemaining;
    private bool timerIsRunning = false;
    private float startspeed;
    

    void Start()
    {
        float randomNumber = Random.Range(15, 50);
        timeRemaining = randomNumber;
        rb2d = GetComponent<Rigidbody2D>();
        timerIsRunning = true;

        startspeed = speed;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    void Update()
    {

        characterDirection = new Vector2(transform.localScale.x, transform.localScale.y);

        RaycastHit2D hit = Physics2D.Raycast(groundRay.transform.position, Vector2.down, 1f);
        Debug.DrawRay(groundRay.transform.position, Vector2.down,  Color.red);

        RaycastHit2D wallHit = Physics2D.Raycast(groundRay.transform.position, Vector2.right * characterDirection!, 0.5f);
        Debug.DrawRay(groundRay.transform.position, Vector2.right * characterDirection, Color.red);

        rb2d.velocity = new Vector2(Horizontal * speed, rb2d.velocity.y);


        if (timerIsRunning == true)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                speed = 0;
                timerIsRunning = false;
                float randomNumber = Random.Range(2, 5);
                timeRemaining = randomNumber;
            }
        }

        if (timerIsRunning == false)
        {
             if (timeRemaining > 0)
             {
                timeRemaining -= Time.deltaTime;
             }
             else
             {
                speed = startspeed;
                timerIsRunning = true;
                float randomNumber = Random.Range(15, 50);
                timeRemaining = randomNumber;
             }
        }

        if (hit.collider == null)
        {

            Turning(facingRight, Horizontal);

        }

        if (wallHit.collider != null)
        {
             if(wallHit.collider.CompareTag("Wall"))
             {

                 Turning(facingRight, Horizontal);

             }
        }

        groundCheckMethod();
        
    }

    void Turning(bool Hori, float faceRight)
    {
        if (facingRight == true)
        {
            transform.localScale = new Vector3(0.3f, transform.localScale.y, transform.localScale.z);
            Horizontal = -1;
            facingRight = false;

        }
        else
        {
            transform.localScale = new Vector3(-0.3f, transform.localScale.y, transform.localScale.z);
            Horizontal = 1;
            facingRight = true;
        }
    } 

    private void groundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 100f, layerMask);
        if (Hit2D != false)
        {
            Vector2 temp = playerFeet.position;
            temp.y = Hit2D.point.y;
            playerFeet.position = temp;
        }
    }
}
