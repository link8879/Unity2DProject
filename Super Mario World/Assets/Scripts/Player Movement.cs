using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 1.0f;
    [SerializeField] private float spinJumpSpeed = 1.0f;

    private Vector2 moveInput;
    
    private Rigidbody2D playerRigidbody;

    private Animator playerAnimator;

    private bool isSpinJump;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        isSpinJump = false;
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
        Debug.Log(moveInput);
        if (moveInput.y > 0.0f)
        {
            playerAnimator.SetBool("Look Up",true);
            playerAnimator.SetBool("Duck",false);
        }
        else if (moveInput.y < 0.0f)
        {
            playerAnimator.SetBool("Look Up", false);
            playerAnimator.SetBool("Duck", true);
        }
        else
        {
            playerAnimator.SetBool("Look Up", false);
            playerAnimator.SetBool("Duck", false);
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
            if (moveInput.y == 0f)
            {
                playerAnimator.SetBool("Jump", true);
            }
        }
    }

    void OnSpinJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerRigidbody.linearVelocity += new Vector2(0f, spinJumpSpeed);
            playerAnimator.SetBool("SpinJump",true);
            isSpinJump = true;
        }
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed , playerRigidbody.linearVelocity.y);
        playerRigidbody.linearVelocity = playerVelocity;

        bool playerHorizontalSpeed = Mathf.Abs(playerRigidbody.linearVelocity.x) > Mathf.Epsilon;

        if (!isSpinJump)
        {
            playerAnimator.SetBool("Walk", playerHorizontalSpeed);
        }
    }

    void Fall()
    {
        if (playerRigidbody.linearVelocity.y < 0f)
        {
            playerAnimator.SetBool("Fall",true);
        }
        else if(playerRigidbody.linearVelocity.y == 0f)
        {
            playerAnimator.SetBool("Fall",false);
            playerAnimator.SetBool("Jump",false);
            playerAnimator.SetBool("SpinJump",false);
            isSpinJump = false;
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
