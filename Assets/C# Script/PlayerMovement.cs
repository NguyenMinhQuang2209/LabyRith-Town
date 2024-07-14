
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator ani;
    private bool canJump;
    private GameObject inventory;
    private bool isInventoryVisible;
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        
        //player turning left-right
        if (horizontalInput >0.01f) 
        {
            transform.localScale = Vector3.one;
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            
            body.velocity = new Vector2(body.velocity.x, speed);
            canJump = false;
        }

        

        //Set animator parameters
        ani.SetBool("run", horizontalInput != 0);

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
    private void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventory.SetActive(isInventoryVisible);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }
    private void Awake()
    {
        //Grab reference for rigidbody and animation from object
        body = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        // Find the Inventory GameObject under the Canvas
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            inventory = canvas.transform.Find("Inventory").gameObject;
            inventory.SetActive(false); // Initially hide the Inventory
        }
        else
        {
            Debug.LogError("Canvas not found!");
        }

        // Initialize Inventory state
        isInventoryVisible = false;
    }

}
