using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject; // The object the camera will follow
    public float Distance = 10f; // Maximum distance behind the player
    public float cameraHeight = 5f; // How high above the player the camera is
    public float updateSpeed = 10f; // How fast the camera moves to its target position

    private Vector3 initialForward; // The initial forward direction of the tracked object

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