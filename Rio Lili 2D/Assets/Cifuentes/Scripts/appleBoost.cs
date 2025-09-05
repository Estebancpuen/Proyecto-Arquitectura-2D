using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleBoost : MonoBehaviour
{
    public float aumentoVelocidad = 2f;  // cuánto aumenta la velocidad
    public float duracion = 5f;          // duración del efecto (segundos)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSimple jugador = other.GetComponent<PlayerSimple>();
            if (jugador != null)
            {
                // Aumentar velocidad
                jugador.StartCoroutine(AumentarVelocidadTemporal(jugador));
                Destroy(gameObject); // destruir la manzana
            }
        }
    }

    private System.Collections.IEnumerator AumentarVelocidadTemporal(PlayerSimple jugador)
    {
        jugador.velocidad += aumentoVelocidad;

        yield return new WaitForSeconds(duracion);

        jugador.velocidad -= aumentoVelocidad; // volver a la normalidad
    }
}
