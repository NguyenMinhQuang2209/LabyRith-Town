using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daRoi = false;
    public Transform diemKhoiPhuc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !daRoi)
        {
            rb.isKinematic = false;
            daRoi = true;
            Invoke("KhoiPhuc", 4f);
        }

    }
    
    private void KhoiPhuc()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularDrag = 0;
        transform.position = diemKhoiPhuc.position;
        daRoi = false;
    }
}
