using System.Collections;
using UnityEngine;

public class ContenedorNivel10Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 10
    public GameObject[] enemigosNivel10;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel10)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(10);
        
        foreach (GameObject enemigo in enemigosNivel10)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 10 completado.");
    }
}
