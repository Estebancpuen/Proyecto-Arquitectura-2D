using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // necesario para Slider / Image
using UnityEngine.SceneManagement; // 👈 para reiniciar o cambiar de escena si quieres

public class barraAgua : MonoBehaviour
{
    [Header("UI de la barra (elige uno)")]
    public Slider barraSlider;
    public Image barraImage;

    [Header("Objeto Agua (sprites del mundo)")]
    public SpriteRenderer[] aguaRenderers;

    [Header("Configuración")]
    public float reduccionPorSegundo = 0.01f;
    public float cantidadRecuperacion = 0.2f;
    public Color colorLleno = Color.cyan;
    public Color colorVacio = Color.red;

    private float agua = 1f;
    private bool gameOverActivado = false;

    void Update()
    {
        if (gameOverActivado) return; // si ya terminó, no seguir

        // Reducir agua con el tiempo
        agua -= reduccionPorSegundo * Time.deltaTime;
        agua = Mathf.Clamp01(agua);

        ActualizarUI();
        ActualizarAguaSprites();

        // Verificar Game Over
        if (agua <= 0f && !gameOverActivado)
        {
            ActivarGameOver();
        }
    }

    public void RecuperarAgua()
    {
        agua += cantidadRecuperacion;
        agua = Mathf.Clamp01(agua);
        ActualizarUI();
        ActualizarAguaSprites();
    }

    void ActualizarUI()
    {
        if (barraSlider != null)
            barraSlider.value = agua;

        if (barraImage != null)
            barraImage.fillAmount = agua;
    }

    void ActualizarAguaSprites()
    {
        if (aguaRenderers != null && aguaRenderers.Length > 0)
        {
            Color nuevoColor = Color.Lerp(colorVacio, colorLleno, agua);
            foreach (SpriteRenderer sr in aguaRenderers)
            {
                if (sr != null)
                    sr.color = nuevoColor;
            }
        }
    }

    void ActivarGameOver()
    {
        gameOverActivado = true;
        Debug.Log("GAME OVER: Te quedaste sin agua 💧");

        FindAnyObjectByType<gameOver>().MostrarGmaeOver();
        Time.timeScale = 0f;
    }
}
