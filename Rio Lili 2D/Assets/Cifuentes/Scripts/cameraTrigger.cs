using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrigger : MonoBehaviour
{
    [Header("Cámara")]
    public Camera camara;
    public Vector3 nuevaPosicion;
    public float nuevoSize = 5f;
    public float velocidadTransicion = 2f;

    private bool enTransicion = false;
    private camera scriptFollow;

    [Header("UI")]
    public CanvasGroup canvasMensaje;
    public float fadeSpeed = 2f;
    public float duracion = 2f;

    private bool yaActivado = false; // <-- NUEVO: evita que se repita

    private void Start()
    {
        if (camara != null)
            scriptFollow = camara.GetComponent<camera>();

        if (canvasMensaje != null)
            canvasMensaje.alpha = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !yaActivado) // <-- chequea si ya pasó
        {
            yaActivado = true; // se marca como usado

            // Desactivar el seguimiento
            if (scriptFollow != null)
                scriptFollow.enabled = false;

            enTransicion = true;

            // Mostrar mensaje
            if (canvasMensaje != null)
                StartCoroutine(MostrarMensaje());
        }
    }

    private void Update()
    {
        if (enTransicion && camara != null)
        {
            // Lerp de posición
            camara.transform.position = Vector3.Lerp(
                camara.transform.position,
                new Vector3(nuevaPosicion.x, nuevaPosicion.y, camara.transform.position.z),
                Time.deltaTime * velocidadTransicion
            );

            // Lerp del size
            camara.orthographicSize = Mathf.Lerp(
                camara.orthographicSize,
                nuevoSize,
                Time.deltaTime * velocidadTransicion
            );
        }
    }

    IEnumerator MostrarMensaje()
    {
        // Fade In
        while (canvasMensaje.alpha < 1)
        {
            canvasMensaje.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        // Espera en pantalla
        yield return new WaitForSeconds(duracion);

        // Fade Out
        while (canvasMensaje.alpha > 0)
        {
            canvasMensaje.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
