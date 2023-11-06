using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;

    private float xRotation;
    private float yRotation;

    private float mouseX;
    private float mouseY;

    private void Start()
    {
        // looking the cursor to the middle of the screene and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!InventorySystem.Instance.isOpen)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // control rotation around x axis (Look up and down)
            xRotation -= mouseY;

            // clamp the rotation so we can't over-rotate (-90 deg to 90 deg)
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            // control rotation around y axis (Look left and right)
            yRotation += mouseX;

            //
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}
