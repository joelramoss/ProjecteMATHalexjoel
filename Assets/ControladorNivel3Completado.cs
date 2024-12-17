using System.Collections;
using UnityEngine;

public class ControladorNivel3Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 3
    public GameObject[] enemigosNivel3;
    
    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel3)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel3();
        }
    }

    void CompletarNivel3()
    {
        // Marca el nivel 3 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(3);
        Debug.Log("Nivel 3 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel3)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
