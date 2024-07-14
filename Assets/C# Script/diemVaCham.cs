using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diemVaCham : MonoBehaviour
{
    private fallTrap fallTrap;
    void Start()
    {
        fallTrap = GetComponent<fallTrap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
        }
        
        
    }
    // Update is called once per frame
    
}
