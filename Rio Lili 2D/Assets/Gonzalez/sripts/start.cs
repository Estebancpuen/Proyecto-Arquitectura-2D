using UnityEngine;
using UnityEngine.SceneManagement; // 👈 necesario para cambiar de escena

public class MenuInicio : MonoBehaviour
{
    // Método público para el botón
    public void IniciarJuego()
    {
        // Carga la escena del juego (asegúrate de ponerla en Build Settings)
        SceneManager.LoadScene("Escena Rio");
    }

    // (Opcional) Método para salir del juego
    public void Salir()
    {
        Application.Quit();

        // Si estás en el editor, esto detiene la ejecución
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
