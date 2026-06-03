using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Método para manejar el evento de clic
    public void OnPlayButtonClicked()
    {
        // Cargar la escena del nivel 1
        SceneManager.LoadScene(1);
    }
}
