using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNivel2Completado : MonoBehaviour
{
    // Lista de enemigos que deben ser eliminados para completar el nivel
    public List<GameObject> enemigosDelNivel;

    void Start()
    {
        // Aquí puedes inicializar o comprobar si tienes enemigos en la escena
        // Asegúrate de asignar los enemigos manualmente o encontrar todos los enemigos automáticamente
    }

    void Update()
    {
        // Verificar si todos los enemigos han sido eliminados
        if (enemigosDelNivel.Count == 0)
        {
            CompletarNivel2();
        }
    }

    // Método que se llama cuando el nivel se completa
    void CompletarNivel2()
    {
        // Marca el nivel 2 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(2);
        Debug.Log("Nivel 2 completado. Actualizando estado.");

        // Actualizar las esferas del mapa
        ControladorEsferasMapa controladorEsferas = FindObjectOfType<ControladorEsferasMapa>();
        if (controladorEsferas != null)
        {
            controladorEsferas.ActualizarEsferas(); // Actualiza las esferas en el mapa
        }
        else
        {
            Debug.LogError("ControladorEsferasMapa no encontrado en la escena.");
        }
    }

    // Este método puede ser llamado cuando un enemigo es destruido o eliminado
    public void EliminarEnemigo(GameObject enemigo)
    {
        if (enemigosDelNivel.Contains(enemigo))
        {
            enemigosDelNivel.Remove(enemigo);
        }
    }
}
