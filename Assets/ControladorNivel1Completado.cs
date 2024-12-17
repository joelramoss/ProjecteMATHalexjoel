using System.Collections;
using UnityEngine;

public class ControladorNivel1Completado : MonoBehaviour
{
    // Referencia a los enemigos del nivel 1
    public GameObject[] enemigosNivel1;  // Array para almacenar los enemigos

    void Update()
    {
        bool todosEliminados = true;

        // Verificar si todos los enemigos han sido eliminados
        foreach (GameObject enemigo in enemigosNivel1)
        {
            if (enemigo != null)  // Si el enemigo aún existe
            {
                todosEliminados = false;
                break;
            }
        }

        // Si todos los enemigos han sido eliminados, completar el nivel
        if (todosEliminados)
        {
            CompletarNivel1();
        }
    }

    void CompletarNivel1()
    {
        // Marcar el nivel como completado
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(1);
        Debug.Log("Nivel 1 completado.");

        // Desactivar los enemigos
        foreach (GameObject enemigo in enemigosNivel1)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }
    }
}
