using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMarker : MonoBehaviour
{
    public int levelIndex;  // Índice del nivel (escena) que corresponde a este círculo
    public string levelName; // O el nombre del nivel, si prefieres usar el nombre en lugar de la escena numérica
    public Text interactionMessage;  // Texto UI que se mostrará al interactuar

    private void Start()
    {
        if (interactionMessage != null)
        {
            interactionMessage.gameObject.SetActive(false); // Desactivar el mensaje al inicio
        }
    }

    private void Update()
    {
        // Detectar clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))  // 0 significa clic izquierdo
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            // Verificar si el rayo colisionó con el collider del círculo
            if (hit.collider != null && hit.collider.CompareTag("LevelMarker")) // Asegúrate de poner esta etiqueta en tus círculos
            {
                // Si el clic fue sobre este objeto, cargamos el nivel
                Debug.Log("Círculo clickeado, cargando nivel...");
                LoadLevel();
            }
        }
    }

    // Método para cargar el nivel
    private void LoadLevel()
    {
        // Cargar el nivel de dos formas:
        // 1. Usando el índice de la escena
        SceneManager.LoadScene(levelIndex);

        // 2. Usando el nombre de la escena
        // SceneManager.LoadScene(levelName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            // Mostrar el mensaje de interacción
            if (interactionMessage != null)
            {
                interactionMessage.gameObject.SetActive(true);
                interactionMessage.text = "Haz clic para acceder al nivel " + levelName;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Desactivar el mensaje cuando el jugador se aleja del círculo
        if (other.CompareTag("Player"))
        {
            if (interactionMessage != null)
            {
                interactionMessage.gameObject.SetActive(false);
            }
        }
    }
}
