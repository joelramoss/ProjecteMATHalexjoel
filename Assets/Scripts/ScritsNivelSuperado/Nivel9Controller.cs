using UnityEngine;

public class Nivel9Controller : MonoBehaviour
{
    public void CompletarNivel9()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(9); // Actualiza la variable global de Nivel 9
        Debug.Log("Nivel 9 completado. Actualizando estado.");

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
