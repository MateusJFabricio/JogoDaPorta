﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velocidade;
    public int forcaPulo;
    private bool estaChao = true, impulsoDir = true, impulsoEsq = true;

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
            impulsoDir = true;
            impulsoEsq = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");

        if (moveH > 0)
            if (transform.localScale.x < 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        if (moveH < 0)
            if (transform.localScale.x > 0)
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);


        //Mover para a direita
        if ((moveH > 0) && estaChao)
        {
            rb.velocity = new Vector2(moveH * velocidade, rb.velocity.y);
        }
        //Mover para a esquerda
        else if ((moveH < 0) && estaChao)
        {
            rb.velocity = new Vector2(moveH * velocidade, rb.velocity.y);
        }
        //Pular
        if (Input.GetKeyDown(KeyCode.Space) && estaChao)
        {
            rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            estaChao = false;
        }

        //Impulso direita
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
        }
        //Impulso esquerda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
        }

    }
}