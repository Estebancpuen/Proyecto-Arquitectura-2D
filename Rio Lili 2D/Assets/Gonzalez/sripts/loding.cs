

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loding : MonoBehaviour
{
    public void cargarLvl()
    {
        StartCoroutine(CargarConEspera());
    }

    IEnumerator CargarConEspera()
    {
        // Espera 4 segundos
        yield return new WaitForSeconds(4f);

        // Cargar escena "Loading"
        SceneManager.LoadScene("Loading");
    }
}

