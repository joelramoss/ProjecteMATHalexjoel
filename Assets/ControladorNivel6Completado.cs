using System.Collections;
using UnityEngine;

public class ControladorNivel6Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 6
    public GameObject[] enemigosNivel6;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel6)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel6();
        }
    }

    void CompletarNivel6()
    {
        // Marca el nivel 6 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(6);
        Debug.Log("Nivel 6 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel6)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
