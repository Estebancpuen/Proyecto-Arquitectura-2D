using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        // Obtiene la duraci�n de la animaci�n del Animator
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationTime); // destruye el prefab despu�s de la animaci�n
        }
        else
        {
            // Por si acaso no hay Animator, destruye en 2 segundos
            Destroy(gameObject, 2f);
        }
    }
}
