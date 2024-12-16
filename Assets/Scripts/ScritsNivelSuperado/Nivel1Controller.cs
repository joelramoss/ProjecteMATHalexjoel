using UnityEngine;

public class Nivel1Controller : MonoBehaviour
{
    public void CompletarNivel1()
    {
        // Accede a la variable estática directamente desde la clase GestorDeNivelesGlobal
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(1); // Actualiza la variable global de Nivel 1
        Debug.Log("Nivel 1 completado. Actualizando estado.");

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
