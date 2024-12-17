using System.Collections;
using UnityEngine;

public class ControladorNivel10Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 10
    public GameObject[] enemigosNivel10;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel10)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel10();
        }
    }

    void CompletarNivel10()
    {
        // Marca el nivel 10 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(10);
        Debug.Log("Nivel 10 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel10)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
