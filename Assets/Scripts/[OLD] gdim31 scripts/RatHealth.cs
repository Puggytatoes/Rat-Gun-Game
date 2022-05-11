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
    public float timeInvincible = 1f;
    public float stopTime = 0.75f;

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

    public void OnCollisionStay2D(Collision2D collision)
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
            Freeze();
        }
    }


    public void Hurt()
    {
        if (isInvincible)
            return;
        isInvincible = true;
        invincibleTimer = timeInvincible;
        if (Health.GetHearts() > 1)
        {
            anim.SetTrigger("Ouch");
        }

        else if (Health.GetHearts() == 1)
        {

            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");
            anim.SetBool("isDead", true);
        }
            
        Health.RemoveHeart();
        audiomanager.instance.PlaySFX("damaged");
    }

    public void Freeze()
    {
        StartCoroutine(FreezeRoutine());
    }

    private IEnumerator FreezeRoutine()
    {
        PlayerController.speed = 0;
        PlayerController.jumpPower = 0;

        yield return new WaitForSeconds(stopTime);

        PlayerController.speed = 7; // change to not hard coded value later if possible
        PlayerController.jumpPower = 35;
    }
    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Game Over");
    }
}