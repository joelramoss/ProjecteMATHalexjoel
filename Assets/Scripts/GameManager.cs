using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;  // Instancia del Singleton
    public TextMeshProUGUI mensajeErrorText;  // Referencia al objeto Text que mostrará el mensaje
    public string dificultad;  // Variable global para guardar la dificultad seleccionada

    void Awake()
    {
        // Implementación del patrón Singleton
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);  // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruye esta nueva
        }
    }

    // Método que se llamará cuando se elija la dificultad
    public void SeleccionarDificultad(string dificultadSeleccionada)
    {
        dificultad = dificultadSeleccionada;  // Guarda la dificultad seleccionada en la instancia global
        if (mensajeErrorText != null)
        {
            mensajeErrorText.gameObject.SetActive(false);  // Oculta el mensaje de error si se elige una dificultad
        }
        Debug.Log("Dificultad seleccionada: " + dificultad);
    }

    // Método que se llamará al hacer clic en "Iniciar"
    public void IniciarJuego()
    {
        // Verificar si se ha seleccionado la dificultad
        if (!string.IsNullOrEmpty(dificultad))
        {
            SceneManager.LoadScene("Jugar");  // Cambia "Jugar" por el nombre de tu escena
        }
        else
        {
            // Mostrar el mensaje en rojo si no se ha seleccionado la dificultad
            if (mensajeErrorText != null)
            {
                mensajeErrorText.text = "Siusplau, primer escull una dificultat";  // Establece el mensaje de error
                mensajeErrorText.gameObject.SetActive(true);  // Muestra el mensaje de error
            }
            Debug.LogWarning("No se ha seleccionado dificultad.");
        }
    }

    // Método para cambiar a la escena de selección de dificultad
    public void AnaraEscena()
    {
        SceneManager.LoadScene("Dificultat");  // Cambia "Dificultat" por el nombre de tu escena de selección de dificultad
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






