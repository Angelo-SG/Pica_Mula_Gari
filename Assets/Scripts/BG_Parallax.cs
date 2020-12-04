using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_Parallax : MonoBehaviour
{
    Material mt;
    Vector2 deslocamento;

    public float intensidadeParallax;

    void Start(){
        // Instância um renderizador de sprites
        SpriteRenderer renderizadorDeSprite = GetComponent<SpriteRenderer>();
        // Atribui o primeiro material do sprite à variável "mt"
        mt = renderizadorDeSprite.material;
        // Atribui a propriedade de deslocamento da textura à variável "deslocamento"
        deslocamento = mt.mainTextureOffset;
    }

    void Update(){
        MoveFundo();
    }

    public void MoveFundo(){
        // Divide o valor do efeito parallax pelo espaço de tempo (em segundos)
        // entre cada frame e em seguida atribui o resultado no deslocamento do
        // eixo x do material
        deslocamento.x += Time.deltaTime / intensidadeParallax;
        // Atribui o valor de deslocamento para a textura principal do material
        mt.mainTextureOffset = deslocamento;
    }
}
