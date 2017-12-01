using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed; //variavel de velocidade
    public float jumpPower; //variavel da força do pulo
    public Rigidbody2D playerRigidbody; 
    public SpriteRenderer sprite;

    public Animator anim;

    public Transform ground; 
    public bool grounded;
    public LayerMask groundLayer;

    public int currentColor; //variavel da cor atual

    public Color colorBlack; //cor preta
    public Color colorWhite; //cor branca

    public SpriteRenderer sr;

    
    void Start() //configura a cor inicial do Player
    {
        currentColor = 1; 
        sr.color = colorBlack; 
    }

    void Update() //atualiza as ações
    {
        moves();
        Jump();
        ColorSwitch();
    }

    private void moves() //confifura a ação de correr
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerRigidbody.velocity = new Vector2 (speed, playerRigidbody.velocity.y);
            sprite.flipX = false; //a imagem não inverte
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
            sprite.flipX = true; //a imagem inverte
        }
        else
        {
            playerRigidbody.velocity = new Vector2(0f, playerRigidbody.velocity.y);          
        }
    }

    private void Jump() //configura a ação de pular
    {
        grounded = Physics2D.OverlapCircle(ground.position, 0.2f, groundLayer); 
        anim.SetBool("Jump", !grounded);
        if(Input.GetKeyDown(KeyCode.Space) && grounded) //verifica se a tecla espaço foi apertada e verifica se o player esta no chão
        {
            playerRigidbody.AddForce(Vector2.up * jumpPower);
        }
    }

                                               /////////////////////////////////////
                                              //esta parte não foi completa ainda//
                                             /////////////////////////////////////
    
    private void ColorSwitch() //configura a ação de trocar de cor
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentColor == 2) //troca a cor para branco
            {
                currentColor = 1;
                sr.color = colorWhite;
            }
            else if (currentColor == 1) //troca a cor para preto
            {
                currentColor = 2;
                sr.color = colorBlack;
            }
        }
    }
}