using System.Collections;
using UnityEngine;

public class ControladorNivel5Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 5
    public GameObject[] enemigosNivel5;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel5)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel5();
        }
    }

    void CompletarNivel5()
    {
        // Marca el nivel 5 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(5);
        Debug.Log("Nivel 5 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel5)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
