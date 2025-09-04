using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Header("Configuración")]
    public Transform cam;          // Cámara a seguir
    public float parallaxSpeed = 0.5f; // 0.2 lejano, 0.8 cercano
    public float suavizado = 5f;   // cuanto mayor, más suave

    private float startPosX;
    private Vector3 targetPos;

    void Start()
    {
        if (cam == null && Camera.main != null)
            cam = Camera.main.transform;

        startPosX = transform.position.x;
        targetPos = transform.position;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        // Calcular posición deseada
        float dist = cam.position.x * parallaxSpeed;
        targetPos = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

        // Suavizar movimiento
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * suavizado);
    }

}
