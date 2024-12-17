using System.Collections;
using UnityEngine;

public class ControladorNivel2Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 2
    public GameObject[] enemigosDelNivel;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosDelNivel)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel2();
        }
    }

    void CompletarNivel2()
    {
        // Marca el nivel 3 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(2);
        Debug.Log("Nivel 2 completado.");

        // Desactivar enemigos restantes (si es necesario)
        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosDelNivel)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
