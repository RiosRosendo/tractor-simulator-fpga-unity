using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CornCollector : MonoBehaviour
{
    private int corn = 0; // Variable para rastrear la cantidad de maíz recolectado

// mando a llamar la funcion de get cron la cual es privada pero con get corn la hago publica 
    public int GetCorn() 
    {
        return corn;
    }

    public TextMeshProUGUI CornText; // Referencia al texto en pantalla para mostrar la cantidad de maíz

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");
        if (other.transform.tag == "Corn") // Verificar si el objeto que entra en el trigger es de etiqueta "Corn"
        {
            corn++; // Incrementar la cantidad de maíz recolectado
            CornText.text = "Corn: " + corn.ToString(); // Actualizar el texto en pantalla
            Debug.Log("Corn collected: " + corn); // Mostrar en la consola la cantidad de maíz recolectado
            Destroy(other.gameObject); // Destruir el objeto de maíz recolectado

            // Verificar en qué nivel se encuentra el jugador y si tiene suficiente maíz para pasar al siguiente nivel
            if (SceneManager.GetActiveScene().buildIndex == 1 && corn >= 50)
            {
                // Cargar la escena del nivel 2
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2 && corn >= 100)
            {
                // Cargar la escena del nivel 3
                SceneManager.LoadScene(3);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3 && corn >= 150)
            {
                // Cargar la escena de victoria
                SceneManager.LoadScene(6);
            }
        }
    }
}
