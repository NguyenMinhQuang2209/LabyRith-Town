using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Transform player;
    public Animator playerAnimator;
    public float MoveSpeed = 1f;
    public Transform targetPos;
    public TextMeshProUGUI childTxt;
    public GameObject endGame;
    private void Start()
    {
        endGame.SetActive(false);
    }
    private void Update()
    {
        if (player.transform.position.x >= targetPos.position.x)
        {
            playerAnimator.enabled = false;
            endGame.SetActive(true);
        }
        else
        {
            player.transform.position = new(player.transform.position.x + MoveSpeed * Time.deltaTime, player.transform.position.y, player.transform.position.z);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
