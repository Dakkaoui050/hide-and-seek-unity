using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ai : MonoBehaviour
{   
    // The player character
    public GameObject player;

    // The hiding spots in the environment
    public GameObject[] hidingSpots;

    // The AI's current hiding spot
    private GameObject currentHidingSpot;

    // The distance at which the AI can see the player
    public float sightRange = 10.0f;

    // The distance at which the player can see the AI
    public float playerSightRange = 5.0f;

    // The AI's field of view
    public float fieldOfView = 60.0f;

    // The speed at which the AI can move
    public float movementSpeed = 5.0f;

    // The AI's current state (hiding or chasing)
    private string currentState = "hiding";

    void Start()
    {
        // Choose a random hiding spot to start in
        currentHidingSpot = hidingSpots[Random.Range(0, hidingSpots.Length)];
        transform.position = currentHidingSpot.transform.position;
    }

    public void Update()
    {
        // Calculate the distance between the AI and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // If the AI is hiding and the player is within sight range, switch to chasing state
        if (currentState == "hiding" && distanceToPlayer < sightRange)
        {
            currentState = "chasing";
        }
        // If the AI is chasing and the player is out of sight range, switch to hiding state
        else if (currentState == "chasing" && distanceToPlayer > sightRange)
        {
            currentState = "hiding";
        }

        // If the AI is in the hiding state, stay hidden
        if (currentState == "hiding")
        {
            // Check if the player can see the AI
            bool playerCanSeeAI = CanSeeObject(player, transform, playerSightRange, fieldOfView);
            if (playerCanSeeAI) currentState = "chasing";
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    found found = GetComponent<found>();
                    if (found != null)
                    {
                        found.foundOut++;
                    }                  
                    
                    print("punt");
                   
                    Destroy(this.gameObject);
                   
                } 
                
            }
            
        }
    }

    bool CanSeeObject(GameObject observer, Transform target, float sightRange, float fieldOfView)
    {
        // Get the vector pointing from the observer to the target
        Vector3 direction = (target.transform.position - observer.transform.position).normalized;

        // Check if the angle between the observer's forward direction and the direction to the target is within the observer's field of view
        float angle = Vector3.Angle(observer.transform.forward, direction);
        if (angle > fieldOfView / 2)
        {
            return false;
        }

        // Check if there are any colliders blocking the line of sight between the observer and the target
        RaycastHit hit;
        if (Physics.Raycast(observer.transform.position, direction, out hit, sightRange))
        {
            if (hit.collider.gameObject == target)
            {
                
                return true;
            }
        }

        return false;
    }
   

    
}