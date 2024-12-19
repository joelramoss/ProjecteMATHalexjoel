using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    // Método para cargar la escena "Nivel2"
    public void RestartScene()
    {
        SceneManager.LoadScene("Jugar"); // Carga directamente la escena "Nivel2"
    }
}
