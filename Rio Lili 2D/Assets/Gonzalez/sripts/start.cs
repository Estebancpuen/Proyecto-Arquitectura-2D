using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuInicio : MonoBehaviour
{
   
    public void IniciarJuego()
    {
     
        SceneManager.LoadScene("Contexto");
    }

  
    public void Salir()
    {
        Application.Quit();

        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
