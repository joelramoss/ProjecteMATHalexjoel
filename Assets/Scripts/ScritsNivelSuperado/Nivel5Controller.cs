using UnityEngine;

public class Nivel5Controller : MonoBehaviour
{
    public void CompletarNivel5()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(5); // Actualiza la variable global de Nivel 5
        Debug.Log("Nivel 5 completado. Actualizando estado.");

        // Actualizar esferas del mapa
        ControladorEsferasMapa controladorEsferas = FindObjectOfType<ControladorEsferasMapa>();
        if (controladorEsferas != null)
        {
            controladorEsferas.ActualizarEsferas(); // Llama al método para actualizar las esferas
        }
        else
        {
            Debug.LogError("ControladorEsferasMapa no encontrado en la escena.");
        }
    }
}
