using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barravida : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (vidaMaxima <= 0)
        {
            Debug.LogWarning("vidaMaxima tiene un valor inválido: " + vidaMaxima);
            vidaMaxima = playerController.vida; // Evitar división por cero
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (rellenoBarraVida == null || playerController == null) return;
        rellenoBarraVida.fillAmount = playerController.vida / vidaMaxima;
    }   
}
