using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class found : MonoBehaviour
{
    public GameObject[] AI;

    public TextMeshProUGUI Found_Text;

    public int hiding;
    public int foundOut;

    spectatormode spectator;

    // Start is called before the first frame update
    void Start()
    {
        spectator = GetComponent<spectatormode>();
    }

    // Update is called once per frame
    void Update()
    {
        hiding = AI.Length;

        if (foundOut == hiding)
        {
             spectator.StartCoroutine(spectator.Spectate());
        }

        if (Found_Text == null)
        {
            Found_Text = GameObject.Find("FoundText").GetComponent<TextMeshProUGUI>();
        }

        Found_Text.text = string.Format($"{foundOut} / {hiding}" );
        
      
    }
    public void fountCount()
    {
        print("er komt een punt erbij");
        foundOut++;
    }


}
