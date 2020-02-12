using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public
    public float maxSpeed = 10;
    public float jumpSpeed = 5;

    // private
    Rigidbody2D playerRigidBody;
    SpriteRenderer playerSpriteRenderer;
    Animator animatorPlayer;

    bool facingRight = true;
    bool canJump = true;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        animatorPlayer = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

    }

    void MovePlayer()
    {
        //moving the player feature is not required
        float move = Input.GetAxis("Horizontal");
        //myAnim.SetFloat("speed", Mathf.Abs(move)); //playing the animation//
        playerRigidBody.velocity = new Vector2(move * maxSpeed, playerRigidBody.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        // jump
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animatorPlayer.SetBool("isJumping", true);
            canJump = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        playerSpriteRenderer.flipX = !facingRight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            canJump = true;
            animatorPlayer.SetBool("isJumping", false);
        }
    }
}