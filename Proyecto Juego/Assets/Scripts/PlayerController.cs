using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float horizontal;
    public Rigidbody2D theRB;
    public float jumpForce;
    
    // suelo
    public Transform groundedCheckpoint;
    public LayerMask whatIsGround;
    public Transform wallCheck;
    public LayerMask wallLayer;

    private bool isGrounded;
    public bool isFlip=false;

    static public bool isDoubleJump;
    public bool canDoubleJump;

    private float tiempoEnElAire;
    
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    
    private float coyoteTime = 0.2f;
    private float contadorCoyoteTime;

    private float potenciadorTiempoSalto = 0.2f;
    private float contadorPotenciadorSalto;

    static public bool canWallJump = false;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(6f, 8f);


    public Transform controladorDisparo;

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

      //  RaycastHit2D raycastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundedCheckpoint.position, 0.15f, whatIsGround);
        horizontal = Input.GetAxisRaw("Horizontal");

        if(!isWallJumping)
        {
            theRB.velocity = new Vector2(moveSpeed * horizontal , theRB.velocity.y);

        }


       
        if(isGrounded)
            {
                contadorCoyoteTime = coyoteTime ;

                if(isDoubleJump)
                {
                    canDoubleJump = true;
                }
                else 
                {
                    canDoubleJump = false;
                }
            }
        else 
            {
                contadorCoyoteTime -= Time.deltaTime;
            }
            
        if(Input.GetButtonUp("Jump") && theRB.velocity.y > 0f)
            {
                theRB.velocity = new Vector2(theRB.velocity.x , theRB.velocity.y * 0.5f);
                contadorCoyoteTime = 0f;
            }

        if(Input.GetButtonDown("Jump"))
            {
                contadorPotenciadorSalto = potenciadorTiempoSalto;
            if(contadorCoyoteTime > 0f && contadorPotenciadorSalto > 0f)
            {
                theRB.velocity = new Vector2( theRB.velocity.x , jumpForce);
                contadorPotenciadorSalto = 0f;
            }else 
            {
                if(!isWallSliding)
                {
                    if(canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x , jumpForce);
                        canDoubleJump = false;
                    }
                }
            }
       
        }
        else 
        {
            contadorPotenciadorSalto -= Time.deltaTime;
        }
            
    

       
        if(canWallJump)
        {
            wallSlide();
            wallJump();
        }
           


        if(!isWallJumping)
        {
            isFlip = FlipSprite();
        }
       
     

        anim.SetFloat("velocidadMov", Mathf.Abs(theRB.velocity.x));

        
           
        
    }


    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.3f, wallLayer);
    }

    
    private void wallSlide()
    {
      if(isWalled() && !isGrounded && horizontal != 0f)
      {
        isWallSliding = true;
        theRB.velocity = new Vector2(theRB.velocity.x, Mathf.Clamp(theRB.velocity.y, -wallSlidingSpeed, float.MaxValue));
      }
      else
      {
        isWallSliding = false;
      }
    }

    public bool FlipSprite()
    {
        if(theRB.velocity.x < 0f && !isFlip)
        {
           // theSR.flipX = true;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            return true;

        }
        else if(theRB.velocity.x > 0f && isFlip)
        {
            //theSR.flipX = false;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            return false;
        }
        if(isFlip)
        {
            return true;
        }
        else 
        {
            return false;
        }
           
    }

    private void wallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
           if(isFlip)
           {
            wallJumpingDirection = 1;
           }
           else 
           {
            wallJumpingDirection = -1;
           }
           wallJumpingCounter = wallJumpingTime;
           CancelInvoke(nameof(StopWallJumping));
        }
        else 
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            theRB.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y); 
            wallJumpingCounter = 0f;
            
            if( wallJumpingDirection == 1 && isFlip)
            {
                isFlip = FlipSprite();
            }
            else if( wallJumpingDirection == -1 && !isFlip) 
            {
                isFlip = FlipSprite();
            }
            
           
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
            

         
        }

    }

    private void StopWallJumping()
    {
        isWallJumping = false;

    }
}

 /*
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

         if(theRB.velocity.x < 0f && !isFlip)
        {
            theSR.flipX = true;
           
            return true;

        }
        else if(theRB.velocity.x > 0f && isFlip)
        {
            theSR.flipX = false;
            
            return false;
        }
        if(isFlip)
        {
            return true;
        }
        else 
        {
            return false;
        }
        */
