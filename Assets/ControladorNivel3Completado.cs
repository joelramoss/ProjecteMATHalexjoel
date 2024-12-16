using System.Collections;
using UnityEngine;

public class ContenedorNivel3Controller : MonoBehaviour
{
    // Referencia a los enemigos del nivel 3
    public GameObject[] enemigosNivel3;
    
    void Update()
    {
        bool todosEliminados = true;

        foreach (GameObject enemigo in enemigosNivel3)
        {
            if (enemigo != null)
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
        GestorDeNivelesGlobal.MarcarNivelComoCompletado(3);
        
        foreach (GameObject enemigo in enemigosNivel3)
        {
            if (enemigo != null)
            {
                enemigo.SetActive(false);
            }
        }

        Debug.Log("Nivel 3 completado.");
    }
}
