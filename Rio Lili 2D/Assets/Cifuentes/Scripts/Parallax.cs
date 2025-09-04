using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Header("Configuraci�n")]
    public Transform cam;          // C�mara a seguir
    public float parallaxSpeed = 0.5f; // 0.2 lejano, 0.8 cercano
    public float suavizado = 5f;   // cuanto mayor, m�s suave

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

        // Calcular posici�n deseada
        float dist = cam.position.x * parallaxSpeed;
        targetPos = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

        // Suavizar movimiento
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * suavizado);
    }

}
