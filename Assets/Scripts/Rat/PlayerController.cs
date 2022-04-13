using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float speed = 1;
    [SerializeField] float jumpPower = 500;
    [SerializeField] float groundCheckRadius = 0.2f;

    float horizontalValue;
    [SerializeField] bool isGrounded;
    

    bool isJumping = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            isJumping = true;
        else if (Input.GetButtonUp("Jump"))
            isJumping = false;
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, isJumping);
    }

    void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void Move(float dir, bool jumpFlag)
    {

        if (isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            rb.velocity = (new Vector2(0f, jumpPower));
        }

        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}