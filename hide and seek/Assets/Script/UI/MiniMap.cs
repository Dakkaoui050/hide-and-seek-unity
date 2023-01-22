using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{

    public Camera mainCamera;
    public Camera miniMapCamera;
    public RenderTexture miniMapRenderTexture;
    public Image miniMapImage;
 
    void Start()
    {
        miniMapCamera.orthographic = true;
        miniMapCamera.targetTexture = miniMapRenderTexture;
        miniMapImage.material.mainTexture = miniMapRenderTexture;

        //set enemy on another layer for the mini map to not detect Enemy
        miniMapCamera.cullingMask = ~(1 << LayerMask.NameToLayer("MiniMapEnemy"));
    }

    void Update()
    {

        // Find all enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through each enemy
        for (int i = 0; i < enemies.Length; i++)
        {
            // Check if the enemy has a ShowOnMiniMap variable
            if (enemies[i].GetComponent<MiniMapEnemy>() != null && !enemies[i].GetComponent<MiniMapEnemy>().ShowOnMiniMap)
            {
                // If the variable exists and is false, set the enemy's position and rotation to Vector3.zero and Quaternion.identity
                // This will effectively remove the enemy from the mini map
                enemies[i].transform.position = Vector3.zero;
                enemies[i].transform.rotation = Quaternion.identity;
            }
        }


    }
}
