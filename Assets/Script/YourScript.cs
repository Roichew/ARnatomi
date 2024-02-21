using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YourScript : MonoBehaviour
{
    private VibrationController vibrationController;

    private void Start()
    {
        vibrationController = GetComponent<VibrationController>();

        // Verify vibrator object retrieval
        Debug.Log("Vibrator object: " + vibrationController);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float duration = 1f;

            // Start vibration for the specified duration
            vibrationController.StartVibration(duration);
        }
    }
}
