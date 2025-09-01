using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        // Obtiene la duración de la animación del Animator
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, animationTime); // destruye el prefab después de la animación
        }
        else
        {
            // Por si acaso no hay Animator, destruye en 2 segundos
            Destroy(gameObject, 2f);
        }
    }
}
