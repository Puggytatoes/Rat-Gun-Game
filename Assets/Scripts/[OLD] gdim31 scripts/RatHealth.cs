using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Alejandro
public class RatHealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    public void Die()
    {
        anim.SetBool("canScratch", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("deadCantJump", true);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        Debug.Log("removed a heart");
        Health.RemoveHeart();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}