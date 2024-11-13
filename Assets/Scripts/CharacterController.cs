using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteController : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ProcesarMovimiento();
    }
    // Update is called once per frame
    void ProcesarMovimiento()
    {
       float inputMovimiento = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(inputMovimiento * velocidad, GetComponent<Rigidbody2D>().velocity.y);

        GestionarOrientacio(inputMovimiento);

    }
    void GestionarOrientacio(float inputMovimiento)
    {
        if (mirandoDerecha == true && inputMovimiento < 0 || mirandoDerecha == false && inputMovimiento > 0)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}
