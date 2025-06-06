using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{

    private Animator playerAnimator;
    private List<Collider2D> myColliders;
    private Health health;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myColliders = new List<Collider2D>(GetComponentsInChildren<Collider2D>());
        health = GetComponent<Health>();
    }

    public List<Collider2D> GetMyCollider()
    {
        return myColliders;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Mushroom":
                playerAnimator.Play("Transformation");
                Transforming();
                health.SetHealth(health.GetHealt() + 1);
                Destroy(collision.gameObject);
                break;
        }
    }

    void Transforming()
    {

    }
}

