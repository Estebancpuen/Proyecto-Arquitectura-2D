using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textureScroll : MonoBehaviour
{
    public RawImage rawImage;     // Imagen del Canvas (asegúrate que sea RawImage en lugar de Image)
    public Vector2 velocidad = new Vector2(0.1f, 0f); // Dirección y velocidad del desplazamiento

    private void Reset()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        if (rawImage != null && rawImage.material != null)
        {
            // Mueve el offset de la textura en el tiempo
            rawImage.uvRect = new Rect(
                rawImage.uvRect.x + velocidad.x * Time.deltaTime,
                rawImage.uvRect.y + velocidad.y * Time.deltaTime,
                rawImage.uvRect.width,
                rawImage.uvRect.height
            );
        }
    }
}
