using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameController : MonoBehaviour
{
    public void MudarCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
