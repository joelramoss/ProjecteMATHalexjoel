using UnityEngine;

public class Nivel10Controller : MonoBehaviour
{
    public void CompletarNivel10()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(10); // Actualiza la variable global de Nivel 10
        Debug.Log("Nivel 10 completado. Actualizando estado.");

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
