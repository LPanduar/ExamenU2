using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float offsetAngulo = 0f; 

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue valor)
    {
        Vector2 entrada = valor.Get<Vector2>();

        if (entrada.x != 0f && entrada.y != 0f)
        {
            if (movimiento.x != 0f)
                entrada.x = 0f;
            else
                entrada.y = 0f;
        }

        movimiento = entrada.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimiento * velocidad;

        if (movimiento.sqrMagnitude > 0.01f)
        {
            float angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg + offsetAngulo;
            transform.rotation = Quaternion.Euler(0f, 0f, angulo);
        }
    }
}
