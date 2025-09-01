using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaMovimiento : MonoBehaviour
{
    [Header("Configuración del movimiento")]
    public float amplitude = 0.5f;   // Qué tanto sube y baja
    public float speed = 2f;         // Velocidad de la oscilación

    private Vector3[] initialPositions;

    void Start()
    {
        // Guardar la posición inicial de cada hijo
        int childCount = transform.childCount;
        initialPositions = new Vector3[childCount];

        for (int i = 0; i < childCount; i++)
        {
            initialPositions[i] = transform.GetChild(i).localPosition;
        }
    }

    void Update()
    {
        // Calcular la oscilación una sola vez
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        // Aplicar el mismo movimiento a todos los hijos
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 startPos = initialPositions[i];

            child.localPosition = new Vector3(startPos.x, startPos.y + offset, startPos.z);
        }
    }
}
