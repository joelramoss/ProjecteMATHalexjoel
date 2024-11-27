using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDificultad : MonoBehaviour
{

    public void tornaAtras(){
        SceneManager.LoadScene("SampleScene");  // Cambia "Dificultat" por el nombre de tu escena de selección de dificultad
        Debug.Log("Botón presionado");
    }
}


