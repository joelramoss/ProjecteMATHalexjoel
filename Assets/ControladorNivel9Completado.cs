using System.Collections;
using UnityEngine;

public class ContenedorNivel9Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 9
    public GameObject[] enemigosNivel9;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel9)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(9);
        
        foreach (GameObject enemigo in enemigosNivel9)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 9 completado.");
    }
}
