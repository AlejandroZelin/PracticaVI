using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    bool haciaUnLado;
    public float Velocidad;
    public float movX, movY;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        vigilarDireccion();
        mover();

        if (movX < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (movX > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("HaciaUnLado", haciaUnLado);
    }

    void vigilarDireccion()
    {
        if (transform.position.x > 4)
        {
            haciaUnLado = true;
        }

        else if (transform.position.x < 0)
        {
            haciaUnLado = false;
        }
    }
    void mover()
    {
        if (haciaUnLado == true)
        {
            transform.Translate(Velocidad * Vector2.left * Time.deltaTime);
        }
        else
        {
            transform.Translate(Velocidad * Vector2.right * Time.deltaTime);
        }
    }
}
