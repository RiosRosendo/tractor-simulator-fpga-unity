using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuShortcut : MonoBehaviour
{
    void Update()
    {
        // Verificar si se presiona la tecla "M" (mayúscula o minúscula)
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.M))
        {
            // Cargar la escena del menú (escena 4)
            SceneManager.LoadScene(4);
        }
    }
}