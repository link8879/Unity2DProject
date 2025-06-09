using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = -1f;
    public float force = 5f;

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
                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.AddForce(bounceForce, ForceMode2D.Impulse);
                EnemyCollisionHandle();              
            }
            else
            {
                // 플레이어 체력 감소
            }
        }
    }

    protected abstract void EnemyCollisionHandle();

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
