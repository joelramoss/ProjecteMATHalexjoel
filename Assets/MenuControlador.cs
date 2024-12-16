using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas

public class MenuControlador : MonoBehaviour
{
    // Este método se llama cuando se pulsa el botón "Jugar"
    public void Jugar()
    {
        SceneManager.LoadScene("Jugar"); // Cambia "Jugar" por el nombre exacto de tu escena de juego
    }

    // Este método se llama cuando se pulsa el botón "Com Jugar"
    public void ComJugar()
    {
        SceneManager.LoadScene("ComJugar"); // Cambia "ComJugar" por el nombre de la escena que crearás más adelante
    }

    // Este método se llama cuando se pulsa el botón "Sortir"
    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Para depuración en el editor
        Application.Quit(); // Cierra la aplicación (no funciona en el editor, pero sí en un ejecutable)
    }
}
