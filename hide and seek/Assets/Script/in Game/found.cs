using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class found : MonoBehaviour
{
    public List<GameObject> AI;

    Ai AIScript;

    public TextMeshProUGUI Found_Text;

    public int hiding = 0;
    public int foundOut = 0;

    spectatormode spectator;

    // Start is called before the first frame update
    void Start()
    {
        spectator = GetComponent<spectatormode>();
    }

    // Update is called once per frame
    void Update()
    {
        hiding = AI.Count();

        if (foundOut == hiding)
        {
            print("alle objects zijn gevonden");
        }

        if (Found_Text == null)
        {
            Found_Text = GameObject.Find("FoundText").GetComponent<TextMeshProUGUI>();
        }

        

        Found_Text.text =  $"{foundOut} || {hiding}" ;
        
      
    }
   
}



