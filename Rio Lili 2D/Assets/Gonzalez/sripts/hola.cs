
using UnityEngine;

public class hola : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationTime); 
        }
        else
        {
            Destroy(gameObject, 2f); 
        }
    }
}
