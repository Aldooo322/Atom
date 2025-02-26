using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1f; // Variable de punto flotante para almacenar la velocidad de movimiento del jugador.
    public float jumpForce = 2f; // Reducir la fuerza de salto
    private Rigidbody2D rb2d; // Guarda la referencia del componente Rigidbody2D que se requiere para usar las físicas 2D.
    private Animator anim; // Guarda la referencia del componente Animator

    // Use this for initialization
    void Start()
    {
        // Obtener y almacenar una referencia al componente Rigidbody2D para que podamos acceder a ella.
        rb2d = GetComponent<Rigidbody2D>();
        // Obtener y almacenar una referencia al componente Animator para que podamos acceder a ella.
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("No Animator component found on this GameObject.");
        }
    }

    // FixedUpdate se llama en un intervalo fijo y es independiente de la velocidad de fotogramas. Ponga el código de la física aquí.
    void FixedUpdate()
    {
        // Almacene la entrada horizontal actual en una variable de tipo float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Usamos la variable creada para hacer una nueva variable new Vector2 para el movimiento.
        Vector2 movement = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        // Establece la velocidad del Rigidbody2D para un movimiento constante.
        rb2d.velocity = movement;
    }

    // Update se llama una vez por frame
    void Update()
    {
        if (anim == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Playing anim");
            anim.Play("saltar");
            rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Playing anim");
            anim.Play("disparar");
        }
    }
}
