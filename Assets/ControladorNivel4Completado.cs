using System.Collections;
using UnityEngine;

public class ControladorNivel4Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 4
    public GameObject[] enemigosNivel4;

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel4)
        {
            if (enemigo != null) // Si algún enemigo sigue existiendo
            {
                todosEliminados = false;
                break;
            }
        }

        if (todosEliminados)
        {
            CompletarNivel4();
        }
    }

    void CompletarNivel4()
    {
        // Marca el nivel 4 como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(4);
        Debug.Log("Nivel 4 completado.");

        // Desactivar enemigos restantes (si es necesario)
        foreach (GameObject enemigo in enemigosNivel4)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        // Aquí puedes agregar otras lógicas si es necesario para completar el nivel
    }
}
