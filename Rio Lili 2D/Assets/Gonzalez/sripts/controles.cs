using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controles : MonoBehaviour
{
 
    public void controlesMenu()
    {
   
        SceneManager.LoadScene("Controles");
    }


    public void Salir()
    {
        Application.Quit();

      
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
