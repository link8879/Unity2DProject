using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        Debug.Log(Mathf.Sign(rb.linearVelocity.x));
        transform.localScale = new Vector2((Mathf.Sign(rb.linearVelocity.x)), 1f);
    }
}
