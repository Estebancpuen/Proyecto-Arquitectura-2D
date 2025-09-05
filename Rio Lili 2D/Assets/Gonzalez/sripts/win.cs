using UnityEngine;

public class WinController : MonoBehaviour
{
    [Header("Configuración")]
    public int objetivo = 10; // Cantidad de objetos a eliminar para ganar
    private int contador = 0;

    [Header("Pantalla de Win")]
    public GameObject winPanel;

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // Asegúrate que no esté visible al inicio
    }

    // Llama a este método cada vez que destruyas un objeto "Basura"
    public void SumarPunto()
    {
        contador++;

        if (contador >= objetivo)
        {
            MostrarWin();
        }
    }

    private void MostrarWin()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // pausa el juego al ganar (opcional)
            Debug.Log("¡HAS GANADO!");
        }
    }
}

