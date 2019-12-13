using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public int enemySpeed;
    public int xMoveDirection;


    // Update is called once per frame
    void Update()
    {
        // This will make the enemy bounce back when it meets a Collider
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        // This makes the enemy move to the right
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        /*
        if (hit.distance < 0f)
        {
            FlipEnemy();
        }
        void FlipEnemy()
        {
            if (xMoveDirection > 0)
            {
                xMoveDirection = -1;
            }
            else
            {
                xMoveDirection = 1;
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("tree") == true)
        {
            xMoveDirection = xMoveDirection * -1;
        }
        if (target.gameObject.tag.Equals("block") == true)
        {
            xMoveDirection = xMoveDirection * -1;
        }
        if (target.gameObject.tag.Equals("Player") == true)
        {
            Destroy(target.collider.gameObject);
        }
    }
}
