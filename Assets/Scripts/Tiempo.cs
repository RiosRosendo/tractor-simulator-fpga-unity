using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa el espacio de nombres TextMeshPro
using UnityEngine.SceneManagement; // Importa el espacio de nombres SceneManagement

public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI texto; // Referencia al componente TextMeshProUGUI para mostrar el tiempo
    public float tiempoInicial = 0; // Tiempo inicial en minutos
    private float tiempoActual; // Tiempo actual en segundos

    void Start()
    {
        tiempoActual = tiempoInicial * 60; // Convertir minutos a segundos
    }

    void Update()
    {
        if (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime; // Reducir el tiempo actual
            texto.text = ConvertirTiempo(tiempoActual); // Actualizar el texto con el tiempo actual
        }
        else
        {
            SceneManager.LoadScene(5); // Cargar la escena 5 cuando el tiempo se agote (Game Over)
        }
    }

    // Función para convertir el tiempo de segundos a minutos y segundos formateados
    string ConvertirTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60); // Obtener la parte entera de los minutos
        int segundos = Mathf.FloorToInt(tiempo % 60); // Obtener la parte entera de los segundos
        return string.Format("{0:00}:{1:00}", minutos, segundos); // Formatear el tiempo en el formato "00:00"
    }
}