using UnityEngine;

public class Health : MonoBehaviour
{
    private int life = 10;
    private int health = 1;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        switch (collision.gameObject.tag)
        {
            case "Mushroom":
                Debug.Log("Mushroom collision detected");
                playerAnimator.Play("Transformation");
                Transforming();
                health++;
                Destroy(collision.gameObject);
                break;
        }
    }

    public int GetHealt()
    {
        return health;
    }

    public int SetHealth(int value)
    {
        health = value;
        return health;
    }

    void Transforming()
    {

    }
}
