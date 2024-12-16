using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importar el gestor de escenas

public class Barravida : MonoBehaviour
{
    public Image rellenoBarraVida;
    public PlayerController playerController;
    private float vidaMaxima;

    void Start()
    {
        if (rellenoBarraVida == null)
        {
            Debug.LogError("rellenoBarraVida no está asignado en el Inspector.");
        }

        playerController = GameObject.FindWithTag("Player")?.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("No se encontró un objeto llamado 'Player' o no tiene el componente PlayerController.");
            return;
        }

        vidaMaxima = playerController.vida > 0 ? playerController.vida : 1f;
    }

    void Update()
    {
        if (rellenoBarraVida == null || playerController == null) return;

        // Actualizar la barra de vida
        rellenoBarraVida.fillAmount = Mathf.Clamp(playerController.vida / vidaMaxima, 0f, 1f);

        // Verificar si la vida llega a 0
        if (playerController.vida <= 0)
        {
            Debug.Log("El jugador se quedó sin vida. Cargando la escena fin_perdido...");
            SceneManager.LoadScene("fin_perdido"); // Cargar la escena de derrota
        }
    }

    // Método para forzar la actualización de la barra
    public void ForzarActualizacionBarra()
    {
        if (rellenoBarraVida != null && playerController != null)
        {
            rellenoBarraVida.fillAmount = Mathf.Clamp(playerController.vida / vidaMaxima, 0f, 1f);
        }
    }
}
