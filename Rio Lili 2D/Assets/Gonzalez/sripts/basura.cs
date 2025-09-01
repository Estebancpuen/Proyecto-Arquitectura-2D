using UnityEngine;

public class DestruirConGolpes : MonoBehaviour
{
    public int golpesNecesarios = 3; // Número de veces que debe saltar encima
    private int contadorGolpes = 0;

    public Animator animator; // Referencia al Animator para la animación de destrucción
    public GameObject explosionPrefab; // Prefab de la explosión

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verificar si el jugador vino desde arriba
            if (collision.contacts[0].normal.y < -0.5f)
            {
                contadorGolpes++;

                if (contadorGolpes >= golpesNecesarios)
                {
                    // Ejecutar animación si hay un Animator
                    if (animator != null)
                    {
                        animator.SetTrigger("Destruir");
                    }

                    // Instanciar explosión
                    if (explosionPrefab != null)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    }

                    // Destruir el objeto después de un pequeño delay
                    Destroy(gameObject, 0.5f);
                }
            }
        }
    }
}
