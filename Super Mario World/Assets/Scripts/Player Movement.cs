using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1.0f;
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
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("1");
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed , playerRigidbody.linearVelocity.y);
        playerRigidbody.linearVelocity = playerVelocity;

        bool playerHorizontalSpeed = Mathf.Abs(playerRigidbody.linearVelocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Walk",playerHorizontalSpeed);
    }


}
