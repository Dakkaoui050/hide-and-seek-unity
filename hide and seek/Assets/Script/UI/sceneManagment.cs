using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManagment : MonoBehaviour
{
    //START SCENE\\

    //begin
    public GameObject start;
    public GameObject OptionButton;
    public GameObject Exit;

    //option to play offline or online 
    public GameObject offline;
    public GameObject online;
    public GameObject GoBack;

    //offline maps to play
    public GameObject MapChoices;

    //option
    public GameObject option;
   
    
   

    public void StartButton()
    {
        start.SetActive(false);
        OptionButton.SetActive(false);
        Exit.SetActive(false);

        offline.SetActive(true); 
        online.SetActive(true);
        GoBack.SetActive(true);
        option.SetActive(false);
    }
    public void GoBackButton()
    {
        start.SetActive(true);
        OptionButton.SetActive(true);
        Exit.SetActive(true);

        offline.SetActive(false);
        online.SetActive(false);
        GoBack.SetActive(false);
        MapChoices.SetActive(false);

        option.SetActive(false);
    }
    public void keuze()
    {
        offline.SetActive(false);
        online.SetActive(false);
        GoBack.SetActive(true);

        MapChoices.SetActive(true);
        
    }

    public void StartOfflineGame(string scene)
    {
        SceneManager.LoadScene(scene);
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
        OptionButton.SetActive(false);
        Exit.SetActive(false); 
        GoBack.SetActive(true);

        option.SetActive(true);

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
