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

    void OnCollision2dEnter(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Mushroom":
                playerAnimator.Play("Transformation");
                Transforming();
                life++;
                break;
        }
    }

    void Transforming()
    {

    }
}
