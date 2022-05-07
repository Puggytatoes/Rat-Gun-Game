using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatHealth : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private GameMaster gm;

    private bool isInvincible;
    private float invincibleTimer;
    public float timeInvincible = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hurt();
            
        }

        if (collision.gameObject.CompareTag("hazard"))
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            transform.position = gm.lastCheckPointPos;
            Hurt();
        }
    }


    public void Hurt()
    {
        
        if (isInvincible)
            return;
        isInvincible = true;
        invincibleTimer = timeInvincible;
        if (Health.GetHearts() > 1)
            anim.SetTrigger("Ouch");
        else if (Health.GetHearts() == 1)
            anim.SetTrigger("Death");
        Health.RemoveHeart();
        audiomanager.instance.PlaySFX("damaged");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}