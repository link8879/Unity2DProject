using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private Animator blockAnimator;
    bool isTouched = false;
    
    void Start()
    {
        blockAnimator = GetComponent<Animator>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isTouched)
        {
            blockAnimator.SetBool("Touched", true);
            Instantiate(item, transform.position, Quaternion.identity);
            isTouched = true;
        }
    }
}
