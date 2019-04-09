using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;
    public float forcaPulo;
    public Transform groundCheck;
    private bool grounded;
    public AudioClip fxPulo;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            playerRb.AddForce(new Vector2(0, forcaPulo));
            _GameController.fxSource.PlayOneShot(fxPulo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Cenoura":
                {
                    _GameController.Pontuar(10,0);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Ovo":
                {
                    _GameController.Pontuar(50,1);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Pedra":
                {
                    _GameController.DanoPontuar(50);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Espinho":
                {
                    _GameController.DanoPontuar(25);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Arvore":
                {
                    _GameController.DanoPontuar(10);
                    Destroy(collision.gameObject);
                    break;
                }
            case "Madeira":
                {
                    _GameController.MudarCena("04_Fim");
                    break;
                }
            default:
                {
                    break;
                }
        }


    }
}
