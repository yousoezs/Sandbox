﻿using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    private bool isCursorVisible = false; 

    public float Sensitivity = 300f;
    public Transform player;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);

        MouseState();
        ShowMouse();

    }
    public void MouseState()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isCursorVisible = !isCursorVisible;
        }
    }
    public void ShowMouse()
    {
        if(isCursorVisible)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
