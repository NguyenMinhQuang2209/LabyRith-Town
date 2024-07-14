using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject player;
    public Sprite OpenDoorImage;
    public Sprite CloseDoorImage;
    public float TimeBeforeNextScene;
    public bool PlayerIsAtTheDoor;
    public float XDefaultMin;
    public float XDefaultMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E) && PlayerIsAtTheDoor==true && (player.transform.position.x > XDefaultMax && player.transform.position.x < XDefaultMin))
        {
            StartCoroutine(_OpenDoor());
        }
    }
    public IEnumerator _OpenDoor()
    {
        transform.GetComponent<SpriteRenderer>().sprite = OpenDoorImage;
        yield return new WaitForSeconds(TimeBeforeNextScene);
        player.SetActive(false);
        yield return new WaitForSeconds(TimeBeforeNextScene);
        transform.GetComponent<SpriteRenderer>().sprite = CloseDoorImage;
        yield return new WaitForSeconds(TimeBeforeNextScene);
        SceneManager.LoadScene("MyHouse");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainPlayer")
        {
            PlayerIsAtTheDoor = true;
        }
    }
}
