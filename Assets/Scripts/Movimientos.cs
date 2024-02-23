using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{
    public float movX, movY;
    public float velocidad = 3f;
    private Rigidbody2D fisicas;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool quieroSaltar;
    public bool estarSuelo;
    public float fuerzasalto = 200;
    public static bool crecer;
    public GameObject SonidoAupa;
    

    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        crecer = false;
        fuerzasalto = 7;
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movX * velocidad, fisicas.velocity.y);

        fisicas.velocity = movimiento;

        if (Input.GetButtonDown("Jump"))
        {   
                quieroSaltar = true;
            SonidoAupa.gameObject.SetActive(true);
        }
        SonidoAupa.gameObject.SetActive(!quieroSaltar);

        if (movX < 0)
        {
            spriteRenderer.flipX = true;
        }
        
        else if (movX > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetFloat("VelX", movimiento.x);
        animator.SetBool("Salto", !estarSuelo);

        if(crecer)
        {
            animator.SetBool("Crecer", crecer);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terreno")
        {
            estarSuelo = true;
        }
    }

    private void FixedUpdate()
    {
        if(quieroSaltar  && estarSuelo)
        {
            fisicas.AddForce(Vector2.up * fuerzasalto, ForceMode2D.Impulse);
            quieroSaltar = false;
            estarSuelo = false;
        }
        
    }
}
