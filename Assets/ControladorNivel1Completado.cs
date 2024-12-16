using System.Collections;
using UnityEngine;

public class ContenedorNivel1Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 1
    public GameObject[] enemigosNivel1;  // Array para almacenar los enemigos
    

    // Método para comprobar si todos los enemigos han sido eliminados
    void Update()
    {
        // Verificar si todos los enemigos han sido eliminados
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel1)
        {
            if (enemigo != null)  // Si el enemigo aún existe, el nivel no está completado
            {
                todosEliminados = false;
                break;
            }
        }

        // Si todos los enemigos han sido eliminados, marcar el nivel como completado
        if (todosEliminados)
        {
            CompletarNivel1();
        }
    }

    // Método que marca el nivel como completado
    void CompletarNivel1()
    {
        // Marcar el nivel como completado en el Gestor de Niveles Global
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(1);
        
        // Opcionalmente, desactivar enemigos y otros elementos
        foreach (GameObject enemigo in enemigosNivel1)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);  // Desactivar enemigos
            }
        }

        Debug.Log("Nivel 1 completado.");
    }
}
