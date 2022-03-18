using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum Movementstate {idle, running, jumping, falling};
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        Update_Animation();
    }


    private void Update_Animation()
    {
        Movementstate state;

        //check if running
        if (dirX > 0f)
        {
            state = Movementstate.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = Movementstate.running;
            sprite.flipX = true;
        }
        else
        {
            state = Movementstate.idle;
        }



        //check if jumping
        if(rb.velocity.y > 0.1f)
        {
            state = Movementstate.jumping;

        } else if (rb.velocity.y < -0.1f)
        {
            state = Movementstate.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
