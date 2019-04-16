using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisoes : MonoBehaviour
{
    public GameObject GerenciamentoPontos;
    private Pontuacao pontuacao;
    // Start is called before the first frame update
    void Start()
    {
        GerenciamentoPontos = GameObject.Find("GerenciamentoPontos");
        pontuacao = GerenciamentoPontos.GetComponent<Pontuacao>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Chave1")
        {
            pontuacao.AcaoChave1();
            Destroy(other.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chave1")
        {
            pontuacao.AcaoChave1();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Chave2")
        {
            pontuacao.AcaoChave2();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Chave3")
        {
            pontuacao.AcaoChave3();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ferpa")
        {
            pontuacao.AcaoFerpa();
        }

        if (other.gameObject.tag == "Porta")
        {
            pontuacao.AcaoPorta();
        }

    }

}
