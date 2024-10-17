using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDificultad : MonoBehaviour
{
    public void SeleccionarDificultad(string dificultad)
    {
        // Asignar la dificultad seleccionada al GameManager
        GameManager.instancia.SeleccionarDificultad(dificultad); // Llama al método de GameManager
    }

    public void tornaAtras(){
        SceneManager.LoadScene("SampleScene");  // Cambia "Dificultat" por el nombre de tu escena de selección de dificultad
        Debug.Log("Botón presionado");
    }
}


