using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleController : MonoBehaviour
{
    [Header("Movimiento de la manzana")]
    public Transform puntoA;         // posición inicial
    public Transform puntoB;         // posición final
    public float velocidad = 2f;     // qué tan rápido se mueve
    private Vector3 destino;

    [Header("Spawner")]
    public GameObject[] applePrefabs;   // prefabs de manzanas (velocidad, salto, etc.)
    public Transform[] spawnPoints;     // emptys donde aparecerán
    public float tiempoEntreSpawns = 5f;

    private void Start()
    {
        if (puntoA != null) transform.position = puntoA.position;
        destino = puntoB.position;

        // Empezar a spawnear manzanas
        InvokeRepeating(nameof(SpawnApple), 2f, tiempoEntreSpawns);
    }

    private void Update()
    {
        // Mover manzana suavemente entre los puntos
        if (puntoA != null && puntoB != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, destino) < 0.1f)
            {
                // Cambiar destino
                destino = (destino == puntoA.position) ? puntoB.position : puntoA.position;
            }
        }
    }

    private void SpawnApple()
    {
        if (applePrefabs.Length == 0 || spawnPoints.Length == 0) return;

        // Seleccionar manzana aleatoria
        GameObject apple = applePrefabs[Random.Range(0, applePrefabs.Length)];

        // Seleccionar punto de spawn aleatorio
        Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar manzana en el punto
        Instantiate(apple, spawn.position, Quaternion.identity);
    }
}
