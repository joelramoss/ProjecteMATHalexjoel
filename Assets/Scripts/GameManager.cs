using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public void IniciarJuego()
    {
            SceneManager.LoadScene("Jugar");  // Cambia "Jugar" por el nombre de tu escena

    }

    // Método para cambiar a la escena de selección de dificultad
    public void AnaraEscena()
    {
        SceneManager.LoadScene("Opcions");  // Cambia "Dificultat" por el nombre de tu escena de selección de dificultad
    }

    public void sortir()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Detener en el editor
    #else
        Application.Quit();  // Cerrar la aplicación en build
    #endif

    }
}






