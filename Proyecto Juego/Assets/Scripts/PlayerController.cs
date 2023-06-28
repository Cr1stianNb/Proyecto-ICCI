using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [Header("Componentes daño")]

    public bool canMove = true;
    [SerializeField] private Vector2 vectorEmpuje; 
    [SerializeField] private BoxCollider2D boxCollider2d;
    public float moveSpeed;
    private float horizontal;
    public Rigidbody2D theRB;
    public float jumpForce;
    
    // suelo
    public Transform groundedCheckpoint;
    public float radioSuelo;
    public LayerMask whatIsGround;
    public Transform wallCheck;
    public LayerMask wallLayer;

    private bool isGrounded;
    public bool isFlip=false;

    public static bool isDoubleJump;
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
    private float wallJumpingDuration = 0.3f;
    private Vector2 wallJumpingPower = new Vector2(6f, 8f);
    private bool isDoubleJumping;
   

    public Transform controladorDisparo;

    public int cantSalto;

    // input buffer

    private Queue<KeyCode> inputBuffer;

    // animator

    private Animator anim;
    private SpriteRenderer theSR;
    // 

    // Gravity scale 

    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2.0f;


    public string proyectoHorizontal;
    public string proyectoJump;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        PlayerPrefs.SetString("LastExitName", "");
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        inputBuffer = new Queue<KeyCode>();
        PlayerController.isDoubleJump = true;
    }

    private void IsGrounded()
    {
        float extraHeightText = .02f;
        RaycastHit2D raycastSuelo = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, whatIsGround);
       // RaycastHit2D raycastSuelo = Physics2D.Raycast(boxCollider2d.bounds.center + boxCollider2d.bounds.center , Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, whatIsGround);

        if(raycastSuelo.collider != null)
        {
            isGrounded = true;
        }
        else 
        {
            isGrounded = false;
        }

        anim.SetBool("IsGrounded", isGrounded);
    }

    // Update is called once per frame
    void Update()
    {

        IsGrounded();
       // isGrounded = Physics2D.OverlapCircle(groundedCheckpoint.position, radioSuelo, whatIsGround);
        horizontal = Input.GetAxisRaw(proyectoHorizontal);

       


       
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


        if(Input.GetButtonDown(proyectoJump))
        {
            if(proyectoJump == "Jump1")
            {
                inputBuffer.Enqueue(KeyCode.Space);
                Invoke("quitarAccion", 0.1f);
            }
            else if(proyectoJump == "Jump2")
            {
                Debug.Log(inputBuffer.Count);
                inputBuffer.Enqueue(KeyCode.DownArrow);
                Invoke("quitarAccion", 0.1f);
            }
            
           // Debug.Log(inputBuffer.Count);
        }


            
        if(Input.GetButtonUp(proyectoJump) && theRB.velocity.y > 0 && !isWallSliding )
        {
          //  theRB.velocity = new Vector2(theRB.velocity.x ,  theRB.velocity.y * 0.6f);
            contadorCoyoteTime = 0f;
            
        }
        
        
         /*
        if(inputBuffer.Count > 0)
        {
            #region salto
                if(inputBuffer.Peek() == KeyCode.Space && !isWallSliding)
                    {
                    contadorPotenciadorSalto = potenciadorTiempoSalto;
                    if(contadorCoyoteTime > 0f && contadorPotenciadorSalto > 0f)
                    {
                        theRB.velocity = new Vector2( theRB.velocity.x , jumpForce);
                        contadorPotenciadorSalto = 0f;
                        
                        quitarAccion();
                        
                            
                    }else 
                    {
                        if(!isWallSliding && inputBuffer.Count > 0)
                        {
                            if(canDoubleJump && inputBuffer.Peek() == KeyCode.Space )
                            {
                            
                                theRB.velocity = new Vector2(theRB.velocity.x , jumpForce);
                                canDoubleJump = false;
                                quitarAccion();
                                
                                
                            }
    
                        }
                    }
            
                }
                else 
                {
                    contadorPotenciadorSalto -= Time.deltaTime;
                }
            #endregion
        }
        */
    

       /*
        if(canWallJump)
        {
            wallSlide();
            wallJump();
        }
           
      */

        if(!isWallJumping)
        {
            isFlip = FlipSprite();
        }
       
     

       
        
           
        
    }

    void FixedUpdate()
    {

        anim.SetFloat("velocidadMov", Mathf.Abs(theRB.velocity.x));
        anim.SetFloat("velocidadY", theRB.velocity.y);

        if(theRB.velocity.y < 0)
        {
            
            theRB.gravityScale = fallMultiplier;
        }
        else if( theRB.velocity.y > 0 && !Input.GetButton(proyectoJump) && !isWallJumping)
        {
            theRB.gravityScale = lowJumpMultiplier;
        }
        else 
        {
            theRB.gravityScale = 1f;
        }


        if(!isWallJumping && canMove)
        {
            theRB.velocity = new Vector2(moveSpeed * horizontal , theRB.velocity.y);

        }

        if(inputBuffer.Count > 0 && canMove)
        {
            #region salto
                if((inputBuffer.Peek() == KeyCode.Space || inputBuffer.Peek() == KeyCode.DownArrow) && !isWallSliding)
                    {
                    //anim.SetTrigger("Jump");
                    contadorPotenciadorSalto = potenciadorTiempoSalto;
                    if(contadorCoyoteTime > 0f && contadorPotenciadorSalto > 0f)
                    {
                        theRB.velocity = new Vector2( theRB.velocity.x , jumpForce);
                       // theRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        contadorPotenciadorSalto = 0f;
                        
                        quitarAccion();
                        
                        
                            
                    }else 
                    {
                        if(!isWallSliding && inputBuffer.Count > 0)
                        {
                            if(canDoubleJump && (inputBuffer.Peek() == KeyCode.Space  || inputBuffer.Peek() == KeyCode.DownArrow) && !isWallJumping )
                            {
                                anim.SetTrigger("Jump");
                                theRB.velocity = new Vector2( theRB.velocity.x , jumpForce);
                               // theRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                                canDoubleJump = false;
                                quitarAccion();
                                
                                
                            }
    
                        }
                    }
            
                }
                else 
                {
                    contadorPotenciadorSalto -= Time.deltaTime;
                }
            #endregion
        }


        if(canWallJump)
        {
            wallSlide();
            wallJump();
        }
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
      }                     // theRB.velocity.x
      else
      {
        isWallSliding = false;
      }
    }

    public bool FlipSprite()
    {   // theRB.velocity.x < 0f &&
        if( !isFlip && horizontal < 0)
        {
           // theSR.flipX = true;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            return true;

        }
        //theRB.velocity.x > 0f &&
        else if( isFlip && horizontal > 0)
        {
            //theSR.flipX = false;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
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
            // Jump
        if(inputBuffer.Count > 0)
        {
            if( inputBuffer.Peek() == KeyCode.Space && wallJumpingCounter > 0f)
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
           

    }

    private void StopWallJumping()
    {
        isWallJumping = false;

    }

    private void quitarAccion()
    {
       if(inputBuffer.Count > 0)
       {
         inputBuffer.Dequeue();
       }
    }

     private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Vector3 direction = new Vector3(0, -0.35f, 0);
        Gizmos.DrawWireSphere(groundedCheckpoint.position, radioSuelo);
        Gizmos.DrawRay(transform.position, direction );
    }

  

    public void Rebote(Vector2 puntoGolpe)
    {
        theRB.velocity = new Vector2(-vectorEmpuje.x * puntoGolpe.x , vectorEmpuje.y); 
    }
}

 