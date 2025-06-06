using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = moveSpeed;
        rb.linearVelocity = new Vector2(velocity.x, velocity.y);
    }
}
