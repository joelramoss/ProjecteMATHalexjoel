using UnityEngine;

public class Nivel3Controller : MonoBehaviour
{
    public void CompletarNivel3()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(3); // Actualiza la variable global de Nivel 3
        Debug.Log("Nivel 3 completado. Actualizando estado.");

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
