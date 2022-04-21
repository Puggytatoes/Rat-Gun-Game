using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            isCrouching = false;
        }
        else if (Input.GetButtonUp("Jump"))
            isJumping = false;

        if (Input.GetButton("Crouch") && isGrounded)
            if (Input.GetButton("Jump"))
                isCrouching = false;
            else
                isCrouching = true;
        else
            isCrouching = false;
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, isJumping, isCrouching);
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
            sprite.color = new Color(0, 255, 255); // REMOVE LATER
        }
        else
        {
            sprite.color = new Color(255, 0, 0); // REMOVE LATER
        }

        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
    }

    void OnDrawGizmosSelected() // This is here just for debugging purposes
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(ceilingCheckCollider.position, ceilingCheckRadius);
    }
}