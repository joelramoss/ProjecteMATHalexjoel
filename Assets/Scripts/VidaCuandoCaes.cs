using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaCuandoCaes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entró tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Obtener el componente PlayerController del objeto Player
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Restar una vida al jugador
                playerController.vida -= 1;
                Debug.Log("El jugador tocó triggerSuelo. Vida restante: " + playerController.vida);

                // Acceder a Barravida y actualizar el fillAmount inmediatamente
                Barravida barraVida = FindObjectOfType<Barravida>();
                if (barraVida != null)
                {
                    barraVida.ForzarActualizacionBarra();
                }
                else
                {
                    Debug.LogError("No se encontró el script Barravida en la escena.");
                }

                // Devolver al jugador a la posición específica
                playerController.transform.position = new Vector2(-25.36f, -5.16f);
                Debug.Log("Jugador devuelto a la posición inicial.");

                // Verificar si la vida llega a 0
                if (playerController.vida <= 0)
                {
                    Debug.Log("El jugador se ha quedado sin vida.");
                    // Aquí puedes añadir lógica para Game Over o reiniciar la escena
                }
            }
            else
            {
                Debug.LogError("El objeto con tag 'Player' no tiene el componente PlayerController.");
            }
        }
    }
}
