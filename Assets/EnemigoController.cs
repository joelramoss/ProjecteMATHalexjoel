using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public bool isMoving = false;
    private bool isAttacking = false;
    private bool mirandoDerecha = false; // Si es true, mira a la derecha; si es false, mira a la izquierda

    public float moveSpeed = 2f; // Velocidad de movimiento
    public Vector2 moveDirection = Vector2.left; // Dirección inicial del movimiento

    void Start()
    {
        // Obtén los componentes necesarios
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Verifica si los componentes están asignados correctamente
        if (animator == null)
        {
            Debug.LogError("No se encontró un componente Animator en el GameObject.");
        }

        if (rb == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody2D en el GameObject.");
        }
    }

    void Update()
    {
        // Control de animaciones
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
            animator.SetBool("isAttacking", isAttacking);
        }

        // Lógica de movimiento
        if (isMoving)
        {
            // Movimiento continuo hacia la dirección actual
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            moveDirection = Vector2.zero; // Detenerse
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TriggerIzquierda"))
        {
            // Actualiza mirandoDerecha a true (mirando a la derecha)
            mirandoDerecha = true;
            GestionarOrientacion();
        }
        else if (other.CompareTag("TriggerDerecha"))
        {
            // Actualiza mirandoDerecha a false (mirando a la izquierda)
            mirandoDerecha = false;
            GestionarOrientacion();
        }
    }

    void GestionarOrientacion()
    {
        if (mirandoDerecha)
        {
            // Mirando a la derecha: escala negativa en X (invertido según tu configuración inicial)
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            moveDirection = Vector2.right; // Cambia la dirección del movimiento hacia la derecha
        }
        else
        {
            // Mirando a la izquierda: escala positiva en X
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            moveDirection = Vector2.left; // Cambia la dirección del movimiento hacia la izquierda
        }
    }

}
