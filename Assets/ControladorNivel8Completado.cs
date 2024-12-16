using System.Collections;
using UnityEngine;

public class ContenedorNivel8Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 8
    public GameObject[] enemigosNivel8;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel8)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(8);
        
        foreach (GameObject enemigo in enemigosNivel8)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 8 completado.");
    }
}
