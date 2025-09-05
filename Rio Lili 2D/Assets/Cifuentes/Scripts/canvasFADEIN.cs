using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasFADEIN : MonoBehaviour
{
    public CanvasGroup canvasGroup; // Asigna tu Canvas aqu�
    public float fadeSpeed = 1.5f;  // Velocidad del fade (m�s alto = m�s r�pido)

    private void Start()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0; // Comienza invisible
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        canvasGroup.alpha = 1; // asegurar que quede totalmente visible
    }
}
