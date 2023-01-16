using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class found : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // if the seeker found the hider destroy the Gameobject
            Debug.Log("Hider clicked!");
            Destroy(gameObject);

        }
    }
}
