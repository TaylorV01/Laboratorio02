using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform objective;  // The player or object the camera will follow
    public Vector3 offset;       // Offset from the player's position

    void Start()
    {
        // Set an initial offset based on the current position of the camera relative to the objective
        offset = transform.position - objective.position;
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the player while maintaining the offset
        Vector3 desiredPosition = objective.position + offset;
        transform.position = new Vector3(desiredPosition.x, transform.position.y, desiredPosition.z);

        // Keep the camera looking at the player
        transform.LookAt(objective);
    }
}
