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


    public float tiempoEnElAire;
    public int cantSalto;
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

        RaycastHit2D raycastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundedCheckpoint.position, .2f, whatIsGround);

        theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal") , theRB.velocity.y);

        if(raycastSuelo == true)
        {
            tiempoEnElAire = 0;
            cantSalto = 0;
        }
        else
        {
            tiempoEnElAire += Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(raycastSuelo == true)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                cantSalto = cantSalto + 1 ;
            }
            else
            {
                if(tiempoEnElAire < 0.25f  && cantSalto < 1)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    cantSalto = cantSalto + 1;
                }
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

//if(isGrounded)
 //           {
  //              theRB.velocity = new Vector2(theRB.velocity.x, jumpForce  );
   //         }