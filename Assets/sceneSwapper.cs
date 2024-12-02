using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{
    public string loadNextSceneByName;
    public bool escenaJugar;
    private bool keyEnable;
    // Start is called before the first frame update
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
                Debug.Log("entra en letra E");
                SceneManager.LoadScene(loadNextSceneByName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!escenaJugar)
                SceneManager.LoadScene(loadNextSceneByName);
            else
            {
                keyEnable=true;
                Debug.Log("entra");
               
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
    // Update is called once per frame

}
