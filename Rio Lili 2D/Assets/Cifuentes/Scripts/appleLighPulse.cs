using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class appleLighPulse : MonoBehaviour
{
    public Light2D luz;             // Referencia a la luz 2D
    public float intensidadMin = 0.5f; // Intensidad mínima
    public float intensidadMax = 1.5f; // Intensidad máxima
    public float velocidad = 2f;       // Velocidad del pulso

    private void Update()
    {
        if (luz != null)
        {
            // Oscilar intensidad con una onda senoidal
            float t = (Mathf.Sin(Time.time * velocidad) + 1f) / 2f;
            luz.intensity = Mathf.Lerp(intensidadMin, intensidadMax, t);
        }
    }
}
