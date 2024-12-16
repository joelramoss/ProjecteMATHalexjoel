using System.Collections;
using UnityEngine;

public class ContenedorNivel5Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 5
    public GameObject[] enemigosNivel5;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel5)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(5);
        
        foreach (GameObject enemigo in enemigosNivel5)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 5 completado.");
    }
}
