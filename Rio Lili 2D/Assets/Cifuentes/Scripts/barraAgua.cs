using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // muy importante para Image/Slider

public class barraAgua : MonoBehaviour
{
    [Header("UI de la barra (elige uno)")]
    public Slider barraSlider;    // opcional: si usas Slider, así lo asignas
    public Image barraImage;      // opcional: si tu barra es una Image tipo Filled

    [Header("Objeto Agua (sprite del mundo)")]
    public SpriteRenderer aguaRenderer; // el sprite que cambiará de color

    [Header("Configuración")]
    public float reduccionPorSegundo = 0.01f; // cuánto porcentaje por segundo (si usas Image, es 0..1)
    public float cantidadRecuperacion = 0.2f; // cuánto recupera (si Image => 0..1)
    public Color colorLleno = Color.cyan;
    public Color colorVacio = Color.red;

    void Update()
    {
        // Si no hay nada asignado, salir (evita errores)
        if (barraSlider == null && barraImage == null) return;

        // Reducir con el tiempo según el tipo de UI
        float porcentaje = 1f;

        if (barraSlider != null)
        {
            float nuevo = barraSlider.value - reduccionPorSegundo * Time.deltaTime;
            barraSlider.value = Mathf.Clamp(nuevo, 0f, barraSlider.maxValue);
            porcentaje = (barraSlider.maxValue > 0f) ? barraSlider.value / barraSlider.maxValue : 0f;
        }
        else // usamos Image
        {
            float nuevo = barraImage.fillAmount - reduccionPorSegundo * Time.deltaTime;
            barraImage.fillAmount = Mathf.Clamp01(nuevo);
            porcentaje = barraImage.fillAmount; // ya está en 0..1
        }

        // Actualizar color del agua (0 -> vacio, 1 -> lleno)
        if (aguaRenderer != null)
        {
            aguaRenderer.color = Color.Lerp(colorVacio, colorLleno, porcentaje);
        }
    }

    // Llamar desde el script de la basura cuando sea destruida
    public void RecuperarAgua()
    {
        if (barraSlider != null)
        {
            barraSlider.value = Mathf.Min(barraSlider.value + cantidadRecuperacion, barraSlider.maxValue);
        }
        else if (barraImage != null)
        {
            barraImage.fillAmount = Mathf.Min(barraImage.fillAmount + cantidadRecuperacion, 1f);
        }
    }
}
