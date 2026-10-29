using UnityEngine;
using UnityEngine.SceneManagement;

public class Pico : MonoBehaviour
{
    private Rigidbody2D miJugador;
    private Collider2D miCollider;

    void Awake()
    {
        miJugador = GetComponentInParent<Rigidbody2D>();
        miCollider = GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D otro)
    {
        if (otro.isTrigger) return;
        if (otro.attachedRigidbody == null || otro.attachedRigidbody == miJugador) return;
        if (otro.attachedRigidbody.GetComponent<MovimientoJugador>() == null) return;

        Pico picoOtro = otro.attachedRigidbody.GetComponentInChildren<Pico>();
        if (picoOtro == null) return;


        Vector2 centroOtro = otro.bounds.center;
        Vector2 frenteOtro = (Vector2)picoOtro.miCollider.bounds.center - centroOtro;
        Vector2 impacto = miCollider.ClosestPoint(centroOtro) - centroOtro;

   
        if (Vector2.Dot(impacto, frenteOtro) >= 0f) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
