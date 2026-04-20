using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 150f;
    private Rigidbody2D rb;
    private Vector2 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        if (Input.GetKeyDown("left shift"))
        {
            speed = 250f;
        }
        if (Input.GetKeyUp("left shift"))
        {
            speed = 150f;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed * Time.deltaTime;
    }
}
