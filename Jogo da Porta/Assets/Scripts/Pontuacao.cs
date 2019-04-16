using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public int tempoInicialSegundos;
    private int tempoAtual;
    public int qntChaves;
    public Text tempoRestante;
    public Text chavesColetadas;
    public Text mensagens;
    public Text msgFimJogo;
    private string mensagem;
    private int tempoExibicao;
    private bool exibirMensagem;
    private bool jogoFinalizado;
    private float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        tempoAtual = tempoInicialSegundos;
        tempoRestante.text = "Tempo Restante:" + tempoAtual.ToString();
        chavesColetadas.text = "Chaves Coletadas:" + qntChaves.ToString();
        StartCoroutine(AtualizarCronometro());
        StartCoroutine(MostraMensagem());
    }

    // Update is called once per frame
    void Update()
    {
        if (jogoFinalizado)
            if (Input.GetKey(KeyCode.R))
            {
                Time.timeScale = timeScale;
                SceneManager.LoadScene("Cena1");
                tempoAtual = tempoInicialSegundos;
                StartCoroutine(AtualizarCronometro());
                StartCoroutine(MostraMensagem());
            }
    }

    private IEnumerator AtualizarCronometro()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            tempoAtual -= 1;
            tempoRestante.text = "Tempo Restante:" + tempoAtual.ToString();
            if (tempoAtual <= 0)
            {
                msgFimJogo.text = "Você Perdeu";
                timeScale = Time.timeScale;
                Time.timeScale = 0;
                jogoFinalizado = true;
                break;
            }
        }
    }

    public void AcaoChave1()
    {
        qntChaves +=1;
        tempoAtual += 5;

        chavesColetadas.text = "Chaves Coletadas:" + qntChaves.ToString();
        if(qntChaves < 4)
            ExibirMensagem("Aeeee.. Mais algumas desta e vc pode sair daqui!", 2);
        else if (qntChaves == 4)
            ExibirMensagem("Finalmente. Vamos embora daqui.", 3);
    }

    public void AcaoFerpa()
    {
        tempoAtual -= 5;
        if (tempoAtual >= 0)
        {
            tempoRestante.text = "Tempo Restante:" + tempoAtual.ToString();
            ExibirMensagem("Você encostou na Ferpa. Perdeu 5 seg. Sai daí", 2);
        }
    }

    public void AcaoChave2()
    {
        tempoAtual -= 100;
        if (tempoAtual >= 0)
        {
            tempoRestante.text = "Tempo Restante:" + tempoAtual.ToString();
            ExibirMensagem("Você pegou a chave do mal. -100 seg. vish", 4);
        }
    }

    public void AcaoChave3()
    {
        tempoAtual -= 10;
        if (tempoAtual >= 0)
        {
            tempoRestante.text = "Tempo Restante:" + tempoAtual.ToString();
            ExibirMensagem("Chave amaldiçoada. Perdeu 30 seg. Tenha cuidado", 2);
        }
    }

    private void ExibirMensagem(string text,int time)
    {
        mensagem = text;
        tempoExibicao = time;
        exibirMensagem = true;
    }

    public void AcaoPorta()
    {
        if(qntChaves >= 4)
        {
            msgFimJogo.text = "Você Ganhou";
            timeScale = Time.timeScale;
            Time.timeScale = 0;
            jogoFinalizado = true;
        }
        else
        {
            ExibirMensagem("Colete as Chaves", 2);
        }
    }

    private IEnumerator MostraMensagem()
    {
        while (true)
        {
            if (exibirMensagem)
            {
                mensagens.text = mensagem;
                yield return new WaitForSeconds(tempoExibicao);
                mensagens.text = "";
                exibirMensagem = false;
            }
            yield return new WaitForSeconds(1);

            if (tempoAtual <= 0)
                break;
        }
    }
}
