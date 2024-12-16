using System.Collections;
using UnityEngine;

public class ContenedorNivel7Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 7
    public GameObject[] enemigosNivel7;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel7)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(7);
        
        foreach (GameObject enemigo in enemigosNivel7)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 7 completado.");
    }
}
