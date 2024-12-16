using UnityEngine;

public class Nivel4Controller : MonoBehaviour
{
    public void CompletarNivel4()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(4); // Actualiza la variable global de Nivel 4
        Debug.Log("Nivel 4 completado. Actualizando estado.");

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
