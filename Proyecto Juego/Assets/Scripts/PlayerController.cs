using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    
    // suelo
    public Transform groundedCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;

    // animator

    private Animator anim;
    private SpriteRenderer theSR;
    // 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundedCheckpoint.position, .2f, whatIsGround);

        theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal") , theRB.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce  );
            }
        }


        anim.SetFloat("velocidadMov", Mathf.Abs(theRB.velocity.x));

        if(theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if(theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }
        
    }
}
