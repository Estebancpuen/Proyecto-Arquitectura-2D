using UnityEngine;

public class DestruirConGolpes : MonoBehaviour
{
    public int golpesNecesarios = 3;
    private int contadorGolpes = 0;

    public Animator animator;
    public GameObject explosionPrefab;
    public barraAgua barraAguaScript;

    [Header("Sonido de explosión")]
    public AudioClip explosionSound;  // Clip de sonido
    private AudioSource audioSource;  // Reproductor de audio

    private void Start()
    {
        // Aseguramos que el objeto tenga un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y < -0.5f)
            {
                contadorGolpes++;

                if (contadorGolpes >= golpesNecesarios)
                {
                    // Animación
                    if (animator != null)
                    {
                        animator.SetTrigger("Destruir");
                    }

                    // Instanciar explosión visual
                    if (explosionPrefab != null)
                    {
                        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    }

                    // Sonido de explosión
                    if (explosionSound != null)
                    {
                        audioSource.PlayOneShot(explosionSound);
                    }

                    // Recuperar agua
                    if (barraAguaScript != null)
                    {
                        barraAguaScript.RecuperarAgua();
                    }

                    // ✅ Avisar al WinController que se destruyó una basura
                    WinController win = FindObjectOfType<WinController>();
                    if (win != null)
                    {
                        win.SumarPunto();
                    }

                    // Destruir después de reproducir sonido y animación
                    Destroy(gameObject, 0.5f);
                }
            }
        }
    }
}
