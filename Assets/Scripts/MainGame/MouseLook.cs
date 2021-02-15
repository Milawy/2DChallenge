using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Variables

    [Header("Player Body")]
    public Transform playerBody;

    [Header("Mouse sensitivity")]
    public float mouseSensitivity = 500f;

    [Header("Minimum & maximum X angles")]
    public float maxXAngle = 46f;
    public float minXAngle = -90f;

    [Header("Look Parameter")]
    public float RaycastRange = 5f;

    [Header("Booleans")]
    public bool raycastHitting2DGame = false;
    public bool showRay = false;

    [HideInInspector] public RaycastHit raycastHit;
    float xRotation = 0f;

    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (showRay) Debug.DrawRay(transform.position, transform.forward * RaycastRange, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out var hit, RaycastRange))
        {
            raycastHitting2DGame = true;
            raycastHit = hit;
        }
        else
        {
            raycastHitting2DGame = false;
        }
    }
}
