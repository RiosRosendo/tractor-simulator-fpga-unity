using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa el espacio de nombres SceneManagement
using UnityEngine.UI;

public class DatosTractor : MonoBehaviour
{
    public float vidaTractor; // Variable para almacenar la vida actual del tractor
    public Slider vidaVisual; // Referencia al Slider que visualiza la vida del tractor

    private void Update()
    {
        // Actualiza el valor del Slider para reflejar la vida actual del tractor
        vidaVisual.GetComponent<Slider>().value = vidaTractor;

        // Verifica si la vida del tractor es menor o igual a cero
        if (vidaTractor <= 0)
        {
            // Carga la escena 5 cuando la vida del tractor llega a cero
            SceneManager.LoadScene(5);
        }
    }
}
