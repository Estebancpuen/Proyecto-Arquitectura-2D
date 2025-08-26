using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Header("Configuración")]
    public Transform cam;          // Cámara a seguir
    public float parallaxSpeed;    // Velocidad relativa (ej: 0.2 lejano, 0.8 cercano)

    private float startPosX;

    void Start()
    {
        if (cam == null && Camera.main != null)
            cam = Camera.main.transform;

        startPosX = transform.position.x;
    }

    void Update()
    {
        if (cam == null) return;

        float dist = cam.position.x * parallaxSpeed;
        transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);
    }

}
