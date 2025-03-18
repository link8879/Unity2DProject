using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 1.0f;

    private Vector2 moveInput;
    
    private Rigidbody2D playerRigidbody;

    private Animator playerAnimator;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Fall();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
            playerAnimator.SetBool("Jump", true);
        }
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed , playerRigidbody.linearVelocity.y);
        playerRigidbody.linearVelocity = playerVelocity;

        bool playerHorizontalSpeed = Mathf.Abs(playerRigidbody.linearVelocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Walk",playerHorizontalSpeed);
    }

    void Fall()
    {
        if (playerRigidbody.linearVelocity.y < 0f)
        {
            Debug.Log(1);
            playerAnimator.SetBool("Fall",true);
            //playerAnimator.SetBool("Jump",false);
        }
        else if(playerRigidbody.linearVelocity.y == 0f)
        {
            playerAnimator.SetBool("Fall",false);
            playerAnimator.SetBool("Jump",false);
        }
        else
        {

        }
    }

    void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(playerRigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(-Mathf.Sign(playerRigidbody.linearVelocity.x), 1f);
        }
    }

}
