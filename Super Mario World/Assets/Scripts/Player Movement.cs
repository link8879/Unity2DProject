using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 1.0f;
    private Vector2 moveInput;
    private Rigidbody2D p_rigidbody;

    void Start()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("1");
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * PlayerSpeed, p_rigidbody.linearVelocity.y);
        p_rigidbody.linearVelocity = playerVelocity;
    }


}
