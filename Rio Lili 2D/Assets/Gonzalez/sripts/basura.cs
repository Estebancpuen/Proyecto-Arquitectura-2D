using UnityEngine;

public class DestruirConGolpes : MonoBehaviour
{
    public int golpesNecesarios = 3; 
    private int contadorGolpes = 0;

    public Animator animator; 
    public GameObject explosionPrefab; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (collision.contacts[0].normal.y < -0.5f)
            {
                contadorGolpes++;

                if (contadorGolpes >= golpesNecesarios)
                {
                    
                    if (animator != null)
                    {
                        animator.SetTrigger("Destruir");
                    }

                    // Instanciar explosión
                    if (explosionPrefab != null)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    }

                  
                    Destroy(gameObject, 0.5f);
                }
            }
        }
    }
}
