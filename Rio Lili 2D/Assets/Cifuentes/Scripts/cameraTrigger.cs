using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrigger : MonoBehaviour
{
    public Camera camara; // arrastra aquí tu cámara
    public Vector3 nuevaPosicion;
    public float nuevoSize = 5f;
    public float velocidadTransicion = 2f;

    private bool enTransicion = false;
    private camera scriptFollow;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        if (camara != null)
            scriptFollow = camara.GetComponent<camera>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactivar el seguimiento
            if (scriptFollow != null)
                scriptFollow.enabled = false;

            enTransicion = true;

            // Convertir este collider en barrera (dejar de ser trigger)
            if (boxCollider != null)
                boxCollider.isTrigger = false;
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
}
