using System;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    private Quaternion rotIni;
    public float velRotX;
    private float countX = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velRotX = 100;
        rotIni = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        countX += Input.GetAxisRaw("Mouse Y") * velRotX * Time.deltaTime;
        countX = Mathf.Clamp(countX, -80, 80);
        Quaternion rotX = Quaternion.AngleAxis(countX, Vector3.left);
        transform.localRotation = rotIni * rotX;
    }
    
    public float GetPitchAngle()
    {
        return countX;
    }
}
