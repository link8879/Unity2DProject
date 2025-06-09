using UnityEditor.Tilemaps;
using UnityEngine;

public class Health : MonoBehaviour
{
    // 추가한 것
    [SerializeField] public RuntimeAnimatorController SmallMario;
    [SerializeField] public RuntimeAnimatorController BigMario;

    private int life = 10;
    private int health = 1;
    public Animator playerAnimator;
    public BoxCollider2D headCollider;
    public BoxCollider2D feetCollider;
    public BoxCollider2D leftCollider;
    public BoxCollider2D rightCollider;


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        headCollider = transform.Find("HeadCollider").GetComponent<BoxCollider2D>();
        feetCollider = transform.Find("FeetCollider").GetComponent<BoxCollider2D>();
        leftCollider = transform.Find("LeftCollider").GetComponent<BoxCollider2D>();
        rightCollider = transform.Find("RightCollider").GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        switch (collision.gameObject.tag)
        {
            case "Mushroom":
                Debug.Log("Mushroom collision detected");
                if (health == 1)
                {
                    playerAnimator.Play("Transformation");
                    Transforming();
                    health++;
                }
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

    public void Transforming()
    {
        playerAnimator.runtimeAnimatorController = BigMario;

        leftCollider.size = new Vector2(0.48f, 1.2f);
        rightCollider.size = new Vector2(0.48f, 1.4f);

        headCollider.offset = new Vector2(0f, 0.75f);
        feetCollider.offset = new Vector2(0f, -0.75f);
    }
}
