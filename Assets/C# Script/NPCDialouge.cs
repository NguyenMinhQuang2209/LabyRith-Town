using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialouge : MonoBehaviour
{
    public GameObject dialougePanel;
    public Text dialogueText;
    public string[] dialouge;
    public int index;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if(dialougePanel.activeInHierarchy)
            {
                zeroText();
            } else
            {
                dialougePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialouge[index])
        {
            contButton.SetActive(true);
        }
    }
    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialougePanel.SetActive(false);
    }
    
    public void NextLine()
    {
        contButton.SetActive(false);
        if(index < dialouge.Length -1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else
        {
            zeroText();
        }
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialouge[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
