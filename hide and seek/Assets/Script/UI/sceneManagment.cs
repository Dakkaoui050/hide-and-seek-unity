using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagment : MonoBehaviour
{
    //START SCENE\\

    //begin
    public GameObject start;
    public GameObject option;
    public GameObject Exit;

    //if i push start on the scene
    public GameObject offline;
    public GameObject online;
    public GameObject GoBack;

    public void StartButton()
    {
        start.SetActive(false);
        option.SetActive(false);
        Exit.SetActive(false);

        offline.SetActive(true); 
        online.SetActive(true);
        GoBack.SetActive(true);

    }
    public void GoBackButton()
    {
        start.SetActive(true);
        option.SetActive(true);
        Exit.SetActive(true);

        offline.SetActive(false);
        online.SetActive(false);
        GoBack.SetActive(false);

    }

    public void StartOfflineGame()
    {
        SceneManager.LoadScene(1);
    }
    public void StartOnlineGame()
    {
        print("werkt nog niet");
    }
    public void exit()
    {
        Application.Quit();
        print("works");
    }
    public void optionButoon()
    {
        print("works");
        start.SetActive(false);
        option.SetActive(false);
        Exit.SetActive(false); 
        GoBack.SetActive(true);
    }
    
    
    //END SCENE offline\\
    public void toMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
    }

   

}
