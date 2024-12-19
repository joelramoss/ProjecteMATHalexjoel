using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarfoc : MonoBehaviour
{
    public GameObject prefabfoc;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generarfocc", 0.5f, 1.5f);
    }
    private void generarfocc (){
        GameObject foc = Instantiate(prefabfoc, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
