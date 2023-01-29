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

    spectatormode spectator;
    private int foundOut;
    private bool allFound;

    // Start is called before the first frame update
    void Start()
    {
        spectator = GetComponent<spectatormode>();
    }

    // Update is called once per frame
    void Update()
    {
        hiding = AI.Length;

        if (!allFound)
        {
            foundOut = 0;
            for (int i = 0; i < AI.Length; i++)
            {
                if (AI[i] != null && !AI[i].activeInHierarchy)
                {
                    foundOut++;
                }
            }

            if (foundOut == hiding)
            {
                allFound = true;
                spectator.StartCoroutine(spectator.Spectate());
            }
        }

        if (Found_Text == null)
        {
            Found_Text = GameObject.Find("FoundText").GetComponent<TextMeshProUGUI>();
        }

        Found_Text.text = string.Format($"{foundOut} / {hiding}" );
    }


}
