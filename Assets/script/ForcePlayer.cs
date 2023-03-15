using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayer : MonoBehaviour
{
    [Header ("Movement")]
    public float jumpHeight = 10;
    public float moveSpeed = 10;
    public Rigidbody rb;
    int timer;
    public bool canjump = true;
    public float gravity;
    Vector3 movementVector;

    [Header ("Flip")]
    bool facingRight = true;
    public GameObject body;

    [Header("GroundCheck")]
    public otherGround checkground;


    [Header("Dash")]
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 5f;
    [SerializeField] private TrailRenderer tr;

    [Header("Teleport")]
    public bool canTp = true;
    public float tpTimer = 0;

    
    private bool canDj = true;
    private bool isDj;
    [Header("DoubleJump")]
    public float djPower = 24f;
    public float djTime = 0.2f;
    public float djCooldown = 5f;
    [SerializeField] private TrailRenderer tr1;

    Passable psb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //se voglio fare in automatico
        psb = GameObject.Find("Piattaforma trapassabile").GetComponent<Passable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (isDj) 
        {
            return;
        }

        if (checkground.isGrounded)
        {
            canDj = true;
        }
        RigidbodyMove();
        RigidbodyJump();

        rb.velocity = movementVector;

        tpTimer += Time.deltaTime;

        if (tpTimer > 0.5)
        {
            canTp = true;
        }
        else
        {
            canTp = false;
        }




        if (Input.GetButtonDown("Fire3") && canDash == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            StartCoroutine(Dash());
        }
        
        
            if (Input.GetButtonDown("Jump") && canDj == true && checkground.isGrounded == false )
            {
                StartCoroutine(DoubleJump());
            }

         if (Input.GetButtonDown("Jump") && canDj == true && psb.isIn== true)
        {
            StartCoroutine(DoubleJump());
        }




        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            Flip();
        }

    }
     void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (isDj)
        {
            return;
        }


        if (checkground.isGrounded == false)
        {
            timer = timer + 1;
        }

        if (checkground.isGrounded == true)
        {
            timer = 0;
        }

        GetComponent<Rigidbody>().AddForce(Vector3.down * gravity);

      

        
    }


    void RigidbodyMove()
    {
        //Movimento (axisraw = unico, axis = curva)
        float xMove = Input.GetAxisRaw("Horizontal");
        movementVector = Vector3.right * xMove * moveSpeed;

       
        movementVector.y = rb.velocity.y;
    }

    void RigidbodyJump ()
    {
        if (checkground.isGrounded == true) 
        {
            canjump = true;
        }

       
     if (Input.GetButtonDown("Jump") && checkground.isGrounded && psb.isIn == false)
        {
            
            Debug.Log(jumpHeight);
            movementVector.y += Mathf.Sqrt(jumpHeight * -2f * (-9.8f));
            canjump = false;
        }
        
        
    }

     IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.useGravity = false;
        rb.velocity = transform.forward * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.useGravity = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
     IEnumerator DoubleJump()
    {
        canDj = false;
        isDj = true;
        rb.velocity = new Vector3(0f, transform.localScale.y * djPower/2);
        tr1.emitting = true;
        yield return new WaitForSeconds(djTime);
        tr1.emitting = false;
        isDj = false;
        
    }

     void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            checkground.isGrounded = true;
        }
    }
   
     void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            checkground.isGrounded = false;
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.Rotate(0, 180, 0);
        

        facingRight = !facingRight;
    }
}
