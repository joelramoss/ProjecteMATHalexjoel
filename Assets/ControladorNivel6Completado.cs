using System.Collections;
using UnityEngine;

public class ContenedorNivel6Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 6
    public GameObject[] enemigosNivel6;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel6)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(6);
        
        foreach (GameObject enemigo in enemigosNivel6)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 6 completado.");
    }
}
