using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAR_Basics : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite player;
    public float spawnX, spawnY;

    private Vector2 spawnPoint = new Vector2();
    private int playerPosition = 2;


    void Start()
    {
        SetSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerMovement();
    }

    void SetSpawn()
{
        // Define os eixos de spawn de acordo com o valor fornecido
        spawnPoint.x = spawnX;
        spawnPoint.y = spawnY;

        // Aplica a mudança de posição do sprite
        transform.position = spawnPoint;
    }

    void SetPlayerMovement()
    {
        // Declaração de variáveis
        bool[] up   = new bool[] {Input.GetKeyDown(KeyCode.W), Input.GetKeyDown(KeyCode.UpArrow)};
        bool[] down = new bool[] {Input.GetKeyDown(KeyCode.S), Input.GetKeyDown(KeyCode.DownArrow)};
        bool[] jump = new bool[] {Input.GetKeyDown(KeyCode.Space)};
        float switchDistance = 1.0f;
        
        // Percorre todo o array 'up' procurando uma tecla pressionada
        foreach (bool key in up)
        {
            // Se a tecla pressionada estiver contida no array:
            if (key)
            {
                // Incrementa e guarda a nova posição do jogador.
                playerPosition++;

                // Move o jogador ao longo do eixo Y
                transform.Translate(0, switchDistance, 0);

                Debug.Log(playerPosition);
            }
        }
            
        // Percorre todo o array 'down' procurando uma tecla pressionada
        foreach (bool key in down)
        {
            // Se a tecla pressionada estiver contida no array :
            if (key)
            {
                // Decrementa a posição do jogador
                playerPosition--;

                // Move o jogador ao longo do eixo Y
                transform.Translate(0, -switchDistance, 0);

                Debug.Log(playerPosition);
            }
        }

        // Se a posição do jogador ultrapassar 3:
        if (playerPosition > 3)
        {
            // Decrementa a posição
            playerPosition--;

            // Move o personagem para baixo
            transform.Translate(0,-switchDistance,0);
        }
        // Senão, se a posição do jogador ficar abaixo de 1:
        else if (playerPosition < 1)
        {
            // Incrementa a posição do jogador
            playerPosition++;

            // Move o personagem para cima
            transform.Translate(0, switchDistance, 0);
        }
        
       




        // Realiza uma ação para cada posição do jogador
        /*switch (playerPosition)
        {
            case 1:
                // Move o jogador ao longo do eixo Y
                transform.Translate(0, switchDistance, 0);
                break;
            default:
                break;
        }*/
    }
}
