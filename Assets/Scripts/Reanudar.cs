using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false; // Variable estática que indica si el juego está pausado
    public GameObject pauseMenuCanvas; // Referencia al canvas del menú de pausa

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                ResumeGame(); // Si el juego está pausado, lo reanuda
            }
            else
            {
                PauseGame(); // Si el juego no está pausado, lo pausa
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el tiempo del juego
        isPaused = true; // Establece la variable de pausa en true
        pauseMenuCanvas.SetActive(true); // Activa el canvas del menú de pausa
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false; // Establece la variable de pausa en false
        pauseMenuCanvas.SetActive(false); // Desactiva el canvas del menú de pausa
    }

    public void Continue()
    {
        ResumeGame(); // Llama a la función para reanudar el juego
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego antes de ir al menú principal
        SceneManager.LoadScene(4); // Cargar la escena del menú principal
    }
}

