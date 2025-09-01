using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscrituraTextos : MonoBehaviour
{
    [Header("Cámara y disparo")]
    public Camera cam;                 // arrastra tu Main Camera aquí
    public float viewportPadding = 0.05f; // margen extra alrededor del viewport
    public bool playOnlyOnce = true;   // animar solo la primera vez

    [Header("Escritura")]
    public float velocidad = 0.05f;    // tiempo entre letras

    private TextMeshPro tmp;
    private string textoCompleto;
    private bool yaEmpezo;

    void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
        textoCompleto = tmp.text;  // usa el texto ya puesto en la escena
        tmp.text = "";             // inicia vacío
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        if (playOnlyOnce && yaEmpezo) return;

        if (EsVisiblePorLaCamara())
        {
            yaEmpezo = true;
            StopAllCoroutines();
            StartCoroutine(AnimarTexto());
        }
    }

    bool EsVisiblePorLaCamara()
    {
        if (cam == null) return false;
        Vector3 vp = cam.WorldToViewportPoint(transform.position);
        return vp.z > 0 &&
               vp.x >= -viewportPadding && vp.x <= 1f + viewportPadding &&
               vp.y >= -viewportPadding && vp.y <= 1f + viewportPadding;
    }

    IEnumerator AnimarTexto()
    {
        tmp.text = "";
        foreach (char c in textoCompleto)
        {
            tmp.text += c;
            yield return new WaitForSeconds(velocidad);
        }
    }

    // Llamar si quieres rearmar y volver a reproducir
    public void ResetAndReplay()
    {
        yaEmpezo = false;
        StopAllCoroutines();
        tmp.text = "";
    }
}
