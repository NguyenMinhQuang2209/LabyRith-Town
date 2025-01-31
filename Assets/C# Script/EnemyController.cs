using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject target;
    float moveSpeed;
    Vector3 directionToTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("MainPlayer");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(0f, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if(target!= null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,directionToTarget.y * moveSpeed );
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}