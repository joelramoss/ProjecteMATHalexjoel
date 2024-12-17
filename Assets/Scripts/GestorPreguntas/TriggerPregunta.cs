using UnityEngine;

public class TriggerPregunta : MonoBehaviour
{
    private GestorPreguntas gestorPreguntas;  // Referencia al script GestorPreguntas

    void Start()
    {
        // Buscar el script GestorPreguntas en la escena
        gestorPreguntas = FindObjectOfType<GestorPreguntas>();

        if (gestorPreguntas == null)
        {
            Debug.LogError("GestorPreguntas no encontrado en la escena. Asegúrate de que el script está en algún objeto.");
        }
    }

void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("OnTriggerEnter2D llamado. Tag del objeto que entró: " + other.tag);

    // Verificar si el objeto que entró en el trigger es el jugador
    if (other.CompareTag("Player"))
    {
        Debug.Log("Player entró en el trigger. Mostrando pregunta.");

        // Obtener el Enemigo_Controller del GameObject actual
        Enemigo_Controller enemigo = GetComponentInParent<Enemigo_Controller>();

        if (enemigo != null)
        {
            // Llamar a MostrarPregunta y pasar el enemigo
            gestorPreguntas.MostrarPregunta(enemigo.gameObject);
        }
        else
        {
            Debug.LogError("Enemigo_Controller no encontrado en el padre del Trigger.");
        }

        // Desactivar el trigger para que no se active nuevamente
        GetComponent<Collider2D>().enabled = false;
    }
}

}