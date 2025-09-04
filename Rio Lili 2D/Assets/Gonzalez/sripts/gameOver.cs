using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{




    public GameObject gameOverPanel;

    public void MostrarGmaeOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

