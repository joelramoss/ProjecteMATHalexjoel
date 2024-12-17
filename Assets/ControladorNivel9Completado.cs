using System.Collections;
using UnityEngine;

public class ControladorNivel9Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 9
    public GameObject[] enemigosNivel9;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel9)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel9();
        }
    }

    void CompletarNivel9()
    {
        // Marca el nivel 9 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(9);
        Debug.Log("Nivel 9 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel9)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
