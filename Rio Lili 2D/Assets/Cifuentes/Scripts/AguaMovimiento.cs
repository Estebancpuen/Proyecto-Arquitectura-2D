using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaMovimiento : MonoBehaviour
{
    [Header("Configuraci�n del movimiento")]
    public float amplitude = 0.5f;   // Qu� tanto sube y baja
    public float speed = 2f;         // Velocidad de la oscilaci�n

    private Vector3[] initialPositions;

    void Start()
    {
        // Guardar la posici�n inicial de cada hijo
        int childCount = transform.childCount;
        initialPositions = new Vector3[childCount];

        for (int i = 0; i < childCount; i++)
        {
            initialPositions[i] = transform.GetChild(i).localPosition;
        }
    }

    void Update()
    {
        // Calcular la oscilaci�n una sola vez
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
