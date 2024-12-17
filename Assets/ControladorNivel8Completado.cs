using System.Collections;
using UnityEngine;

public class ControladorNivel8Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 8
    public GameObject[] enemigosNivel8;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel8)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel8();
        }
    }

    void CompletarNivel8()
    {
        // Marca el nivel 8 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(8);
        Debug.Log("Nivel 8 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel8)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
