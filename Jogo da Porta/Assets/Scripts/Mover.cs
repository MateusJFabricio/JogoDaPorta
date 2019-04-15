using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade;
    public int forcaPulo;
    private bool estaChao = true, impulso = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            estaChao = true;
            impulso = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");

        //Mover para a direita
        if ((moveH > 0) && estaChao)
        {
            if (transform.localScale.x < 0)
             transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(moveH * velocidade, rb.velocity.y);
        }
        //Mover para a esquerda
        else if ((moveH < 0) && estaChao)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(moveH * velocidade, rb.velocity.y);
        }
        //Pular
        if (Input.GetKeyDown(KeyCode.Space) && estaChao)
        {
            rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            estaChao = false;
        }
        //Impulso direita
        if ((moveH > 0) && impulso)
        {
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
            impulso = false;
        }
        //Impulso esquerda
        if ((moveH < 0) && impulso)
        {
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            rb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
            impulso = false;
        }

    }
}
