using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBoss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            gameObject.GetComponent<boss_Run01>().enabled = true;
        }
    }
}
