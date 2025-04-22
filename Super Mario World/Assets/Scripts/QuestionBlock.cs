using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private Animator blockAnimator;

    void Start()
    {
        blockAnimator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Touched the block");
            blockAnimator.SetBool("Touched", true);
        }
    }
}
