using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true;
    private BoxCollider2D boxCollider;
    public LayerMask CapaSuelo;
    private bool estaEnSuelo = false; // Detecta si está tocando el suelo
    private Animator Animator;

    // Límites automáticos del área de juego
    public  int vida = 3;
    // Establecer el límite inferior en -11

    // Posición inicial del jugador
    private Vector2 posicionInicial;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();

        // Guardar la posición inicial del personaje (la posición al inicio del juego)
        posicionInicial = transform.position;

        // Calcular los límites basados en la cámara
        //CalcularLimites();
        Debug.Log("Posición Inicial: " + posicionInicial);  // Verifica la posición inicial

    }

    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            Animator.SetBool("estaCorriendo", true);
        }
        else
        {
            Animator.SetBool("estaCorriendo", false);
        }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        GestionarOrientacion(inputMovimiento);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & CapaSuelo) != 0) // Si está tocando una capa de suelo
        {
            estaEnSuelo = true;
            Debug.Log("El personaje está en el suelo.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & CapaSuelo) != 0)
        {
            estaEnSuelo = false;
            Debug.Log("El personaje salió del suelo.");
        }
    }

    void ProcesarSalto()
    {
        // Solo permitir saltar si el personaje está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            estaEnSuelo = false; // Evitar saltos dobles
            Debug.Log("Salto realizado.");
        }
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        if (inputMovimiento != 0) // Solo cambiar orientación si hay movimiento
        {
            // Cambia la orientación del personaje de forma simplificada
            if (Mathf.Sign(inputMovimiento) != Mathf.Sign(transform.localScale.x))
            {
                mirandoDerecha = !mirandoDerecha;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }


    // Función para restablecer la posición a la inicial


    

}
