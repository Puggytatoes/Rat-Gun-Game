using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite; // REMOVE LATER unless using it for something besides color
    Rigidbody2D rb;
    [SerializeField] Collider2D standingCollider, crouchingCollider;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform ceilingCheckCollider;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float speed = 5;
    [SerializeField] float jumpPower = 30;
    [SerializeField] float decayRate = 5;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] float ceilingCheckRadius = 0.4f;

    float horizontalValue;
    [SerializeField] float crouchSpeedModifier = 0.35f;
    [SerializeField] bool isGrounded;

    [SerializeField] bool isCrouching;
    bool isJumping = false;
    bool facingRight = true;

    public Animator animator;


   


    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [Header("Events")]
    [Space]

    public UnityEvent OnCrouchEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    IEnumerator DoJump()
    {
        //the initial jump
        //rb.AddForce(Vector2.up * jumpPower);
        rb.velocity = (new Vector2(0f, jumpPower));
        yield return null;

        //can be any value, maybe this is a start ascending force, up to you
        float currentForce = jumpPower;

        while (Input.GetKey(KeyCode.Space) && currentForce > 0)
        {
            rb.AddForce(Vector2.up * currentForce);

            currentForce -= decayRate * Time.deltaTime;
            yield return null;
        }
    }


    float dirX;
    float moveSpeed = 5f;
    bool isMoving = false;
    AudioSource rataudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rataudio = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            isCrouching = false;
            animator.SetBool("isJumping", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        if (Input.GetButton("Crouch") && isGrounded)
            if (Input.GetButton("Jump"))
            {
                isCrouching = false;
                animator.SetBool("isCrouching", false);
            }
            else
            {
                isCrouching = true;
                animator.SetBool("isCrouching", true);
            }
        else
        {
            isCrouching = false;
            animator.SetBool("isCrouching", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, isJumping, isCrouching);

        horizontalValue = Input.GetAxisRaw("Horizontal");
        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        if (rb.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;
        if (isMoving && isGrounded)
        {
            if (!rataudio.isPlaying)
                rataudio.Play();
        }
        else
            rataudio.Stop();
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            if (Physics2D.OverlapCircle(ceilingCheckCollider.position, ceilingCheckRadius, groundLayer))
                isGrounded = false; // redundant but for some reason overlapcircle can't return false idk why
            else
                isGrounded = true;
        }
    }

    void Move(float dir, bool jumpFlag, bool crouchFlag)
    {
        if (!crouchFlag)
        {
            if (Physics2D.OverlapCircle(ceilingCheckCollider.position, ceilingCheckRadius, groundLayer))
            {
                crouchFlag = true;
            }

        }
        standingCollider.enabled = !crouchFlag;
        crouchingCollider.enabled = crouchFlag;

        if (isGrounded)
        {
            standingCollider.enabled = !crouchFlag;

            if (jumpFlag)
            {
                isGrounded = false;
                jumpFlag = false;
                StartCoroutine(DoJump());
                //rb.velocity = (new Vector2(0f, jumpPower));
            }
        }
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        if (crouchFlag)
        {
            xVal *= crouchSpeedModifier;
            //sprite.color = new Color(0, 255, 255); // REMOVE LATER

        }
        else
        {
            //sprite.color = new Color(255, 0, 0); // REMOVE LATER
        }

        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }

        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }

        // Set float xVelocity value according to the x value of the rb2d velocity
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }

    void OnDrawGizmosSelected() // This is here just for debugging purposes
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(ceilingCheckCollider.position, ceilingCheckRadius);
    }
}