using UnityEditor.Rendering;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Variables
    public float speed = 150f;
    private Rigidbody2D rb;
    private Vector2 input;

    [SerializeField] 
    
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Gets the players rigid body
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets if the player is walking up or down
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Makes so it isnt faster to walk diagonal
        input.Normalize();

        // Sprint
        if (Input.GetKeyDown("left shift"))
        {
            speed = 250f;
        }
        if (Input.GetKeyUp("left shift"))
        {
            speed = 150f;
        }

        // Changes the animation
        animator.SetBool("IsWalkingDown", Input.GetKey("s"));
        animator.SetBool("IsWalkingUp", Input.GetKey("w"));
        animator.SetBool("IsWalkingRight", Input.GetKey("d"));
        animator.SetBool("IsWalkingLeft", Input.GetKey("a"));
    }

    private void FixedUpdate()
    {
        // Initalizing the movement
        rb.linearVelocity = input * speed * Time.deltaTime;
    }
}
