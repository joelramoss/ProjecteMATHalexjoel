using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour 
{
    [SerializeField]    private GameObject BotonPause;
    [SerializeField]    private GameObject BotonPlay;
    [SerializeField]    private GameObject BotonCasa;
    public void Pausa()
    {
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
