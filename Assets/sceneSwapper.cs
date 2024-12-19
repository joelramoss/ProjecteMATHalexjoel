using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{
    public string loadNextSceneByName; // Nombre de la escena a cargar
    public int nivelActual; // Nivel al que pertenece este portal
    public bool escenaJugar;
    private bool keyEnable;

    public GameObject canva;

    void Start()
    {
        keyEnable = false;
    }

    private void Update()
    {
        if (keyEnable)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Intentando cargar nivel...");
                if (PuedeEntrarNivel())
                {
                    Debug.Log("Nivel permitido. Cargando...");
                    SceneManager.LoadScene(loadNextSceneByName);
                }
                else
                {
                    Debug.LogWarning("¡No has pasado el nivel anterior!");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!escenaJugar)
            {
                if (PuedeEntrarNivel())
                {
                    SceneManager.LoadScene(loadNextSceneByName);
                }
                else
                {
                    Debug.LogWarning("¡No puedes acceder a este nivel aún!");
                    canva.SetActive(true);
                }
            }
            else
            {
                keyEnable = true;
                Debug.Log("Entra en el área de interacción.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            keyEnable = false;
        }
    }

    private bool PuedeEntrarNivel()
    {
        // Verifica si se ha pasado el nivel anterior usando el GestorDeNivelesGlobal
        switch (nivelActual)
        {
            case 2: return GestorDeNivelesGlobal.Nivel1Pasado;
            case 3: return GestorDeNivelesGlobal.Nivel2Pasado;
            case 4: return GestorDeNivelesGlobal.Nivel3Pasado;
            case 5: return GestorDeNivelesGlobal.Nivel4Pasado;
            case 6: return GestorDeNivelesGlobal.Nivel5Pasado;
            case 7: return GestorDeNivelesGlobal.Nivel6Pasado;
            case 8: return GestorDeNivelesGlobal.Nivel7Pasado;
            case 9: return GestorDeNivelesGlobal.Nivel8Pasado;
            case 10: return GestorDeNivelesGlobal.Nivel9Pasado;
            default: return true; // Nivel 1 siempre es accesible
        }
    }
}
