using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool isPlayerFacingRight = true;
    public int playerJumpHeight = 1250;
    private float moveX;
    public bool isPlayerOnGround;
    

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRaycast();

    }

    void PlayerMovement()
    {
        // Controls

        moveX = Input.GetAxis("Horizontal");
        // This will make sure the player can only jump once if he's on the ground
        // so it prevents continuous jumping
        if (Input.GetButtonDown("Jump") && isPlayerOnGround == true)
        {
            Jump();
        }
        // Animation

        // Player Direction
        if (moveX <0.0f && isPlayerFacingRight == false)
        {
            TurnAroundPlayer();
        }
        else if (moveX > 0.0f && isPlayerFacingRight == true)
        {
            TurnAroundPlayer();
        }

        // Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        // Jumping Code
        // We're accessing RigidBody2D and then accessing the AddForce function
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight);
        isPlayerOnGround = false;
    }

    void TurnAroundPlayer()
    {
        // Turn Around Player Code
        // We do this because we don't want the player facing
        isPlayerFacingRight = !isPlayerFacingRight;
        // localScale is a variable for the scale of the player
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if(hit.distance < 2.3f && hit.collider.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<Enemy_Movement>().enabled = false;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            //Destroy(hit.collider.gameObject);
        }
        if (hit.distance < 2.3f && hit.collider.tag != "enemy")
        {
            
            isPlayerOnGround = true;
        }
    }
}
