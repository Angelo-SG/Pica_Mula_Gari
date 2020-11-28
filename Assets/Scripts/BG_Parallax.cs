using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_Parallax : MonoBehaviour
{

    [SerializeField] private Image fundo;
    [SerializeField] private float velocidade;
    private float largura;
    private float posicaoInicial;

    private Transform cameraPrincipal;

    public float efeitoParallax;


    void Start(){
        posicaoInicial  = transform.position.x;
        largura         = GetComponent<SpriteRenderer>().bounds.size.x;
        cameraPrincipal = Camera.main.transform;
    }


    void Update(){
        EfeitoParallax();
    }

    public void MoveFundo(){
        //Aplica o efeito parallax quando uma tecla de movimentação horizontal é pressionada
        transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        //Verifica se a imagem já chegou no final e reposiciona a duplicata para dar a impressão de cenário infinito
        if (transform.position.x >= fundo.preferredWidth){
            transform.position = new Vector3(transform.position.x - fundo.preferredWidth * 2, 0, 0);
            Debug.Log("Funciona!");
        } else if (transform.position.x <= fundo.preferredWidth){ 
            transform.position = new Vector3(transform.position.x + fundo.preferredWidth * 2, 0, 0);
        }
    }

    public void EfeitoParallax()
    {
        float distancia = cameraPrincipal.transform.position.x * efeitoParallax;

        transform.position = new Vector3(posicaoInicial + distancia, 0, 0);

    }
}
