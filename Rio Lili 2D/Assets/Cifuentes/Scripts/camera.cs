using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player;      // jugador a seguir
    public Vector3 offset;        // desplazamiento (ej: (0, 2, -10))

    void LateUpdate()
    {
        if (player == null) return;

        // Actualizar posición de la cámara sumando el offset
        transform.position = new Vector3(
            player.position.x + offset.x,
            player.position.y + offset.y,
            player.position.z + offset.z
        );
    }
}
