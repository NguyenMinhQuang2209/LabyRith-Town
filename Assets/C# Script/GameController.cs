using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;
    private Health playerHealth;

    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;
    // public Transform[] spawnPoints;
    // public GameObject[] enemyPrefbs;
    // int randomSpawnPoint;
    // int randomEnemy;
    // Start is called before the first frame update
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

   // void SpawnEnemy()
   // //    randomSpawnPoint = Random.Range(0, enemyPrefbs.Length);
        //get random enemy prefab
    //    randomEnemy = Random.Range(0,enemyPrefbs.Length);
        //spawm it
   //     Instantiate(enemyPrefbs[randomEnemy], spawnPoints[randomSpawnPoint].position,Quaternion.identity);
   // }
    private void Start()
    {
        checkpointPos = transform.position;

     //   InvokeRepeating("SpawnEnemy", 3f, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("obstacle"))
        {
            Die();
        }
    }
    public void Die()
    {
        StartCoroutine(Respawn(1f));
    }

    IEnumerator Respawn(float duration)
    {
        playerHealth.Respawn();
        playerRb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = new Vector3((float)scaleX, (float)scaleY, 1);
        playerRb.simulated = true;
    }
    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }
}
