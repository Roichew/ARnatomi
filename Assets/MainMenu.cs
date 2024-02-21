using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void keluar()
    {
        Debug.Log("Game Close");
        Application.Quit();
    }

    public void mainkan()
    {
        SceneManager.LoadScene("swipe menu");
    }

    public void tentang()
    {
        SceneManager.LoadScene("About");
    }

    public void settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void awal()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
