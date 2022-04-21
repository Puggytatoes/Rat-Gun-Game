using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CockroachHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private float deathWaitTime;
    [SerializeField]
    private float knockbackTime;

    public Rigidbody2D enemyBody;
    public Animator animator;
    public BoxCollider2D coll;

    public static int numCockroaches = 0;
    private void Start()
    {
        currentHealth = maxHealth;
        coll = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Dead();
            numCockroaches += 1;
            
        }
    }

    void Dead()
    {
        animator.SetBool("isDead", true);
        GetComponent<EnemyMovement>().enabled = false;
        coll.enabled = false;
        enemyBody.bodyType = RigidbodyType2D.Static;
        StartCoroutine(ExampleCoroutine());
    }

    public static void RemoveCockroach(CockroachHealth cockroach)
    {
        Destroy(cockroach.gameObject);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(deathWaitTime);
        RemoveCockroach(this);
    }

    /*
    public void Knockback()
    {
        int dirCheck = RatScratch.ratDir;
        enemyBody.isKinematic = false;
        Vector2 difference = enemyBody.transform.position + transform.position;
        difference = difference.normalized * 25 * -(dirCheck);
        enemyBody.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockbackCo(enemyBody));
    }

    public IEnumerator KnockbackCo(Rigidbody2D Enemy)
    {
        if (enemyBody != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            enemyBody.velocity = Vector2.zero;
            enemyBody.isKinematic = true;
        }
    }
    */
}