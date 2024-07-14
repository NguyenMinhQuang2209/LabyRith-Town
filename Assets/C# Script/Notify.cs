using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notify : MonoBehaviour
{

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void respawnFromLast()
    {
        health.Respawn();
    }
}
