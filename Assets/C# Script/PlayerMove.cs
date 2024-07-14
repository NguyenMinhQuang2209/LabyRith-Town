using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator ani;
    private GameObject inventory;
    private bool canJump;
    private bool isInventoryVisible;
    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemyLayer;
    public float damage;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private TrailRenderer tr;
    private int counter;



    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = false;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    private void Update()
    {
        if(isDashing)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        //player turning left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3((float)scaleX, (float)scaleY, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-(float)scaleX, (float)scaleY, 1);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(counter < 2)
            {

            
            counter++;
            
            ani.SetBool("jump", verticalInput != 0);
            body.velocity = new Vector2(body.velocity.x, speed);
            }
        }
        if (canJump)
        {
            counter = 0;
        }
        if (Input.GetKey(KeyCode.Z)) {
            ani.SetTrigger("fight");

        }
        //Set animator parameters
        ani.SetBool("run", horizontalInput != 0);
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        if(Input.GetKeyDown(KeyCode.X) && canDash) {
            StartCoroutine(Dash());      
         }

    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        if(collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
        
        
        
    }
    
    private void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventory.SetActive(isInventoryVisible);
    }
    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemyLayer);
        foreach(Collider2D enemyGameobject in enemy)
        {
            Debug.Log("hit enemy");
            enemyGameobject.GetComponent<MeleeEnemy01>().health -= damage;
        }
    }
    private void OnDrawGizmos()
    {
        return;
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }


}