using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleJUMP : MonoBehaviour
{
    public float aumentoSalto = 4f;   // cuánto aumenta la fuerza de salto
    public float duracion = 5f;       // duración del efecto (segundos)
    public AudioClip recogerSonido;   // sonido al agarrar
    public float volumen = 1f;        // volumen del sonido

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSimple jugador = other.GetComponent<PlayerSimple>();
            if (jugador != null)
            {
                // Iniciar el efecto de salto aumentado
                jugador.StartCoroutine(AumentarSaltoTemporal(jugador));

                // Reproducir sonido en la posición de la manzana
                if (recogerSonido != null)
                {
                    AudioSource.PlayClipAtPoint(recogerSonido, transform.position, volumen);
                }

                // Destruir la manzana
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator AumentarSaltoTemporal(PlayerSimple jugador)
    {
        jugador.fuerzaSalto += aumentoSalto;

        yield return new WaitForSeconds(duracion);

        jugador.fuerzaSalto -= aumentoSalto; // volver a la normalidad
    }
}
