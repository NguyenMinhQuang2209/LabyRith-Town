using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject codePanel, closedSafe, openedSafe;
    private static bool isSafeOpened = false;
    public bool playerlsClose;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerlsClose)
        {
            if (isSafeOpened)
            {
                codePanel.SetActive(false);
                closedSafe.SetActive(false);
                openedSafe.SetActive(true);
            }
        }
    }
}
