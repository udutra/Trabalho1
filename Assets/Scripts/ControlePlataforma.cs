using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlataforma : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D ponteRb;
    private bool instanciado;

    private void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        ponteRb = GetComponent<Rigidbody2D>();

        ponteRb.velocity = new Vector2(_GameController.velocidadePlataforma, 0);
    }

    private void Update()
    {
        if (instanciado == false && _GameController.contadorPlataformasLevel >= 0)
        {
            if (transform.position.x <= 0 && _GameController.contadorPlataformasLevel > 0)
            {
                instanciado = true;

                int idPrefab = 0;
                int rand = Random.Range(0, 100);
                if (rand < 50)
                {
                    idPrefab = 0;
                }
                else
                {
                    idPrefab = 1;
                }

                GameObject temp = Instantiate(_GameController.plataformaPrefab[idPrefab]);
                float posX = transform.position.x + _GameController.tamanhoPlataforma;
                float posY = transform.position.y;
                temp.transform.position = new Vector3(posX, posY, 0);
                _GameController.contadorPlataformasLevel--;
            }

            else if (transform.position.x <= 0 && _GameController.contadorPlataformasLevel == 0)
            {
                instanciado = true;
                GameObject temp = Instantiate(_GameController.plataformaFim);
                float posX = transform.position.x + _GameController.tamanhoPlataforma;
                float posY = transform.position.y;
                temp.transform.position = new Vector3(posX, posY, 0);
            }
        }

        if (transform.position.x < _GameController.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
