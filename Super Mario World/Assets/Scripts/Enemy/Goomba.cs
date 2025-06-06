using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] float moveSpeed = -1f;
    [SerializeField] float force = 5f;
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
        if(collision.gameObject.CompareTag("Player"))
        {

            if(collision.collider.name == "FeetCollider")
            {
                Vector2 bounceForce = new Vector2(0, force);
                Debug.Log("attack");
                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.AddForce(bounceForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log("Player hit by Goomba");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2((Mathf.Sign(rb.linearVelocity.x)), 1f);
    }
}
