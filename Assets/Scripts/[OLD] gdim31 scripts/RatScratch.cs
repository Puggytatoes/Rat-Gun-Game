using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScratch : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform scratchHitbox;

    [SerializeField]
    private float attackRange;
    public LayerMask enemyLayer;

    [SerializeField]
    private int numDamage;

    [SerializeField]
    private float scratchRate;
    private float nextScratchTime = 0f;
    //private int leftOrRight = 0;
    //private float ratDirection = 0;
    public static int ratDir = 0;

    AudioSource rataudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ratDir = (int)(gameObject.transform.localScale.x / 3);
        if (Time.time >= nextScratchTime)
        {
            if (Input.GetButtonDown("Fire2") && animator.GetBool("canScratch"))
            {
                if (PlayerController.GetCeilingCheck() == false)
                {
                    Scratch();
                    nextScratchTime = Time.time + 1f / scratchRate;
                }
            }
        }
    }
  
    public int GetRatDirection(int rdir)
    {
        return rdir;
    }

   

    void Scratch()
    {
        audiomanager.instance.PlaySFX("scratch");
        animator.SetTrigger("Scratch");
        //check enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(scratchHitbox.position, attackRange, enemyLayer);

        //damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CockroachHealth>().TakeDamage(numDamage);
            enemy.GetComponent<CockroachHealth>().Knockback();
        }
    }
    void OnDrawGizmosSelected()
    {
        if (scratchHitbox == null)
            return;
        Gizmos.DrawWireSphere(scratchHitbox.position, attackRange);
    }
}
