using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject; 
    public float Distance = 10f; 
    public float cameraHeight = 5f; 
    public float updateSpeed = 10f; 

    private Vector3 initialForward; 

    void Start()
    {
        // Capture the initial forward direction of the player
        if (trackedObject != null)
        {
            initialForward = trackedObject.forward;
        }
        else
        {
            Debug.LogError("Tracked object is not assigned!");
        }
    }

    void LateUpdate()
    {
        if (trackedObject == null) return;

        // Use the stable initial forward direction for the camera's calculations
        Vector3 cameraOffset = -initialForward * Distance + Vector3.up * cameraHeight;

        // Calculate the target position for the camera
        Vector3 targetPosition = trackedObject.position + cameraOffset;

        // Smoothly move the camera toward the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, updateSpeed * Time.deltaTime);

        // Optionally keep the camera facing the tracked object
        transform.LookAt(trackedObject.position + Vector3.up * (cameraHeight / 2));
    }
}
//some code was inspired by chatGPT