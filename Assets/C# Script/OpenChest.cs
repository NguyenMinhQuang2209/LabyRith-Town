using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject codePanel, closedSafe, openedSafe;
    public static bool isSafeOpened = false;
    public bool playerIsClose;
    public GameObject player;
    public bool onChest = false;
    void Start()
    {
        codePanel.SetActive(false); // Ensure the code panel is initially hidden

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }

    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose /*&& onChest == true*/)
        {
            codePanel.SetActive(!codePanel.activeSelf);
            
        }
        if (isSafeOpened)
        {
            codePanel.SetActive(false);
            closedSafe.SetActive(false);
            openedSafe.SetActive(true);
        }
    }
     
}
