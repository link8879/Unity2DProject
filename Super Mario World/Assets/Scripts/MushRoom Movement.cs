using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MushRoomMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    [SerializeField] LayerMask blockLayer;

    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    
    Vector2 mushRoomVelocity = new Vector2(0, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 colliderSize = boxCollider.size;
        Vector2 colliderCenter = boxCollider.offset;

        float bottomPosition = colliderCenter.y - (colliderSize.y / 2);
        
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = Vector2.up;

        RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin, rayDirection, bottomPosition, blockLayer);

        if (hitInfo.collider == null)
        {
            if (boxCollider.isTrigger)
            {
                rb.linearVelocity = new Vector2(moveSpeed, 0);
                moveSpeed = moveSpeed * 2;

            }
            boxCollider.isTrigger = false;
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, moveSpeed);
            boxCollider.isTrigger = true;
        }
    }
}
