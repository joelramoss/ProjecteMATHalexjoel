using UnityEngine;

public class Nivel2Controller : MonoBehaviour
{
    public void CompletarNivel2()
    {
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(2); // Actualiza la variable global de Nivel 2
        Debug.Log("Nivel 2 completado. Actualizando estado.");

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
