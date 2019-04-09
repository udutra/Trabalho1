using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            MudarCena("02_Fase1");
        }
    }

    public void MudarCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
