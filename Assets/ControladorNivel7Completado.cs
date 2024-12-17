using System.Collections;
using UnityEngine;

public class ControladorNivel7Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 7
    public GameObject[] enemigosNivel7;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel7)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel7();
        }
    }

    void CompletarNivel7()
    {
        // Marca el nivel 7 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(7);
        Debug.Log("Nivel 7 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel7)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
