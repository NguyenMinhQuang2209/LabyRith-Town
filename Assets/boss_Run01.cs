using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class boss_Run01 : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public bool isFlipped = false;
    private Health playerHealth;
    private Animator anim;

    private float HitNumber;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    public float health;
    public float currentHealth;
   [SerializeField] private float attackCoolDown;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = health;
        HitNumber = 0;
    }
    
    private void Update()
    {
        
        LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newpos);
        anim.SetBool("run", true);
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCoolDown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack02");
                HitNumber += 1;
            }
        }
        if(HitNumber == 3) 
        {
            gameObject.GetComponent<EnemyGeneration>().enabled = true;
            HitNumber = 0;
        }
        if(HitNumber < 3)
        {
            gameObject.GetComponent<EnemyGeneration>().enabled = false;
        }
        if (health < currentHealth)
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

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }  else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private bool PlayerInSight()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayer);
        if (hit.collider != null)
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
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
