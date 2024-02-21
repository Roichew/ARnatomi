using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowModelText : MonoBehaviour
{
    public GameObject model;
    public TextMeshPro textMeshPro;

    private void Update()
    {
        // Check if the model exists and is active
        if (model != null && model.activeInHierarchy)
        {
            // Update the position of the text to match the model's position
            textMeshPro.transform.position = model.transform.position;
        }
    }
}
