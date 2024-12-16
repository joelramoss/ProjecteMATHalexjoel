using UnityEngine;

public class Nivel8Controller : MonoBehaviour
{
    public void CompletarNivel8()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(8); // Actualiza la variable global de Nivel 8
        Debug.Log("Nivel 8 completado. Actualizando estado.");

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
