using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuPausa : MonoBehaviour 
{
    [SerializeField]    private GameObject BotonPause;
    [SerializeField]    private GameObject BotonPlay;
    [SerializeField]    private GameObject BotonCasa;
    public GameObject menuPausa;

    // Start is called before the first frame update
    void Start()
    {
        menuPausa = GetComponent<GameObject>();
        
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        BotonPause.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        BotonPause.SetActive(true);
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
