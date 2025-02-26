using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaciones : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f; // Reducir la velocidad de salto
    private Animator anim;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("No Animator component found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (anim == null) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Playing anim");
            anim.Play("disparar");
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Playing anim");
            anim.Play("Avanzar");
            if (!facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Playing anim");
            anim.Play("Avanzar");
            if (facingRight)
            {
                Flip();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Playing anim");
            anim.Play("saltar");
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
