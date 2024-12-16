using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo_Controller : MonoBehaviour
{
     private Animator animator;
    private Rigidbody2D rb;
    private GestorPreguntas gestorPreguntas; // Referencia al script GestorPreguntas

    // Estados del enemigo
    public bool isMoving = false;
    private bool mirandoDerecha = false;

    // Movimiento
    public float moveSpeed = 2f; // Velocidad del movimiento
    public Vector2 moveDirection = Vector2.left; // Dirección inicial del movimiento

    // Start is called before the first frame update
    void Start()
    {
         // Obtener componentes necesarios
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gestorPreguntas = FindObjectOfType<GestorPreguntas>();

        // Verificaciones
        if (animator == null)
            Debug.LogError("No se encontró un componente Animator en el GameObject.");
    
        if (rb == null)
            Debug.LogError("No se encontró un componente Rigidbody2D en el GameObject.");

        if (gestorPreguntas == null)
            Debug.LogError("GestorPreguntas no encontrado en la escena. Asegúrate de que está presente.");
    
    }

    // Update is called once per frame
    void Update()
    {
           if (animator != null)
            animator.SetBool("isMoving", isMoving);

        // Lógica de movimiento
        if (isMoving)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Detener movimiento
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta si el trigger es "Player" y muestra la pregunta
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado. Mostrando pregunta.");
            gestorPreguntas.MostrarPregunta();

            // Opcional: Detener al enemigo después de activar la pregunta
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        // Detecta otros triggers para cambiar orientación
        else if (other.CompareTag("TriggerIzquierda"))
        {
            mirandoDerecha = true;
            GestionarOrientacion();
        }
        else if (other.CompareTag("TriggerDerecha"))
        {
            mirandoDerecha = false;
            GestionarOrientacion();
        }
    }
     void GestionarOrientacion()
    {
        if (mirandoDerecha)
        {
            // Mirando a la derecha: invertir la escala en X
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            moveDirection = Vector2.right;
        }
        else
        {
            // Mirando a la izquierda: escala positiva en X
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            moveDirection = Vector2.left;
        }
    }
}
