using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Health : MonoBehaviour
{
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator a;

    public void Awake()
    {
        currentHealth = startingHealth;
        a = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth == 0)
        {
            respawnfromLast();
            
            if(GetComponentInParent<EnemyPatrol>() != null)
            {
                a.SetTrigger("die");
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if(GetComponent<MeleeEnemy01>() != null)
            {
                a.SetTrigger("die");
                GetComponent<MeleeEnemy01>().enabled = false;
            }
            
        }   
        
    }
    public void respawnfromLast()
    {
        Respawn();
    }
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
        
    }
    public void Respawn()
    {
        AddHealth(startingHealth);
        
        a.Play("Idle");
        GetComponent<PlayerMove>().enabled = true;
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
