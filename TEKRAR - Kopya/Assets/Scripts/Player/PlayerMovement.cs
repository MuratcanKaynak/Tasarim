using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float inputDirection;
    public float speed;
    private Rigidbody2D rb;
    public float jumpPower;
    private SpriteRenderer sR;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        Movement();
        if (GroundCheck.isGrounded == false)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Jump", true);
        }
        else if(GroundCheck.isGrounded== true)
        {
            anim.SetBool("Jump", false);
        }
    }

    private void CheckInput()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");
        if (inputDirection != 0)
        {
            anim.SetBool("Run", true);
        }
        else if (inputDirection == 0)
        {
            anim.SetBool("Run", false);
        }
        if (inputDirection > 0)
        {
            sR.flipX = false;
        }
        else if (inputDirection < 0)
        {
            sR.flipX = true;
        }


        if (Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    private void Movement()
    {
        rb.velocity = new Vector2(speed * inputDirection, rb.velocity.y);
    }
}
