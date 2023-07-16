using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _transform;
    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private float _xSensitivity = 60f;
    private float _ySensitivity = 60f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void ProcessLook(Vector2 input)
    {
        if(_camera != null)
        {
            float mouseX = input.x * Time.deltaTime * _xSensitivity;
            float mouseY = input.y * Time.deltaTime * _ySensitivity;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            //_xRotation -= (mouseY * Time.unscaledDeltaTime) * _ySensitivity;
            //_xRotation = Mathf.Clamp(_xRotation, -180f, 180f);
            //_camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            //transform.Rotate(Vector3.up * (mouseX * Time.unscaledDeltaTime) * _xSensitivity);
        }
        else
        {
            throw new System.Exception("No camera");
        }
    }
}
