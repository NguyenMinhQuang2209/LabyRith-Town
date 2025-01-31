using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy01 : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Health playerHealth;
    private Animator anim;

    public float health;
    public float currentHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        currentHealth = health;
    }
    
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCoolDown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }
        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        if ((health < currentHealth))
        {
            currentHealth = health;
            anim.SetTrigger("takeHit");
        }
        if (health <= 0)
        {
            anim.SetTrigger("die");
            this.GetComponent<MeleeEnemy01>().enabled = false;
        }
    }
    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range,boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayer);
        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void damagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
