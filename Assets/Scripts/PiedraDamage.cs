using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraDamage : MonoBehaviour
{
    public float damage; // La cantidad de daño que causa la piedra
    public GameObject Player; // Referencia al objeto del jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            // Si la piedra entra en contacto con el jugador, reduce la vida del tractor del jugador
            Player.GetComponent<DatosTractor>().vidaTractor -= damage;
            // Destruye la piedra
            Destroy(gameObject);
        }

        if (other.tag == "Roca")
        {
            // Si la piedra entra en contacto con un objeto con la etiqueta "Roca", muestra un mensaje de depuración
            Debug.Log("Roca");
        }
    }
}

