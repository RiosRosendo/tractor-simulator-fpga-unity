using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoPausa : MonoBehaviour
{
    // Referencia al objeto del menú de pausa
    public GameObject ObjetoMenuPausa;
    
    // Variable para rastrear si el juego está en pausa o no
    public bool Pausa = false;

    void Start()
    {

    }

    void Update()
    {
        // Verificar si se presiona la tecla "P"
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (Pausa == false)
            {
                // Mostrar el menú de pausa y pausar el juego
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;
                
                Time.timeScale = 0; // Detiene el tiempo en el juego
                Cursor.visible = true; // Hace visible el cursor
                Cursor.lockState = CursorLockMode.None; // Permite mover el cursor libremente
            }
            else if (Pausa == true)
            {
                // Resumir el juego
                Resumir();
            }
        }
    }

    // Método para resumir el juego
    public void Resumir()
    {
        // Ocultar el menú de pausa y reanudar el juego
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        
        Time.timeScale = 1; // Reanuda el tiempo en el juego
        Cursor.visible = false; // Oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    // Método para ir al menú principal
    public void IrAMenu(string NombreMenu)
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene(NombreMenu);
    }
}

