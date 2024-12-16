using System.Collections;
using UnityEngine;

public class ContenedorNivel4Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 4
    public GameObject[] enemigosNivel4;

    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel4)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(4);
        
        foreach (GameObject enemigo in enemigosNivel4)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 4 completado.");
    }
}
