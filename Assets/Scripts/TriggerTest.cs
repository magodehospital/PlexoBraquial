using UnityEngine;

public class TrigerTest : MonoBehaviour
{
    // Variable para llevar la cuenta de las colisiones
    public int contador = 0;

    // Esta función se llama cuando otro collider entra en contacto con este objeto.
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó es el jugador
        // Esto asume que tu jugador tiene asignado el tag "Player" en Unity.
        if (other.CompareTag("Player"))
        {
            // Incrementa el contador
            contador++;

            // Muestra el valor actual del contador
            Debug.Log("Contador: " + contador);
        }
    }
}

