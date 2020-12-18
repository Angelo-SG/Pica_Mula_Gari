using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Lanes : MonoBehaviour
{
    // ============================================
    // VARIÁVEIS
    // ============================================

    public float speed;
    public Rigidbody2D Rigidbody2D;

    Vector2 offset;
    // ============================================
    // MÉTODOS
    // ============================================

    // ######### INICIALIZAÇÃO DE VARIÁVEIS

    // ########## TRATA AS ENTRADAS DO TECLADO
    void Update()
    {
        offset.y = Input.GetAxisRaw("Vertical");
    }

    // ########## TRATA OS MOVIMENTOS
    void FixedUpdate()
    {
        // Troca de pista
        Debug.Log("body.position: " + Rigidbody2D.position + " Offset: " + offset);


        Rigidbody2D.MovePosition(Rigidbody2D.position + offset * speed * Time.fixedDeltaTime);
        // Salto
    }
}
