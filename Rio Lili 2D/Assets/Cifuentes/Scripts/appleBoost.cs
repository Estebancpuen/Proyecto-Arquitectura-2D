using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class appleBoost : MonoBehaviour
{
    public float aumentoVelocidad = 2f;  // cuánto aumenta la velocidad
    public float duracion = 5f;          // duración del efecto (segundos)
    public AudioClip sonidoBoost;        // sonido al recoger
    public Image iconoBoost;             // referencia a la imagen del Canvas (UI)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSimple jugador = other.GetComponent<PlayerSimple>();
            if (jugador != null)
            {
                jugador.StartCoroutine(AumentarVelocidadTemporal(jugador));

                // Reproducir sonido si hay audio
                if (jugador.audioSource != null && sonidoBoost != null)
                    jugador.audioSource.PlayOneShot(sonidoBoost);

                Destroy(gameObject); // destruir la manzana
            }
        }
    }

    private IEnumerator AumentarVelocidadTemporal(PlayerSimple jugador)
    {
        jugador.velocidad += aumentoVelocidad;

        // Activar el ícono en el Canvas
        if (iconoBoost != null)
            iconoBoost.enabled = true;

        yield return new WaitForSeconds(duracion);

        jugador.velocidad -= aumentoVelocidad;

        // Desactivar el ícono en el Canvas
        if (iconoBoost != null)
            iconoBoost.enabled = false;
    }
}
