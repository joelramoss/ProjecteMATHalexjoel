using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public Text mensajeError;  // El texto de advertencia en rojo
    private bool dificultadSeleccionada = false;  // Variable para saber si se seleccionó la dificultad

    // Método que se llamará cuando se elija la dificultad
    public void SeleccionarDificultad()
    {
        dificultadSeleccionada = true;  // Cambia a verdadero cuando se selecciona la dificultad
        mensajeError.gameObject.SetActive(false);  // Oculta el mensaje si se elige una dificultad
    }

    // Método que se llamará al hacer clic en "Iniciar"
    public void IniciarJuego()
    {
        if (dificultadSeleccionada)
        {
            SceneManager.LoadScene("NombreDeLaEscena");  // Reemplaza con la escena del juego
        }
        else
        {
            // Muestra el mensaje en rojo si no se ha seleccionado la dificultad
            mensajeError.gameObject.SetActive(true);
        }
    }
}
