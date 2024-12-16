using UnityEngine;

public class Nivel6Controller : MonoBehaviour
{
    public void CompletarNivel6()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(6); // Actualiza la variable global de Nivel 6
        Debug.Log("Nivel 6 completado. Actualizando estado.");

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
