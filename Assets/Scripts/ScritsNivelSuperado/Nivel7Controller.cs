using UnityEngine;

public class Nivel7Controller : MonoBehaviour
{
    public void CompletarNivel7()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(7); // Actualiza la variable global de Nivel 7
        Debug.Log("Nivel 7 completado. Actualizando estado.");

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
