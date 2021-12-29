using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GyroscopeSystem : MonoBehaviour
{
    [SerializeField] private float smoothing = 0.1f;
    [SerializeField] private float speed = 60.0f;
    [SerializeField] private float waitGyroInitializationDuration = 0.5f;
    [SerializeField] private Transform gyroRotation;
    private Quaternion initialRotation;
    private Quaternion gyroInitialRotation;
    private Quaternion offsetRotation;
    public bool GyroEnabled { get; set; }
    public bool debug;

    private void Start()
    {
        if (InputManager.inputGyro == true)
        {
            StartCoroutine(ControllGyro());
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;
        }
        
    }
    private IEnumerator ControllGyro()
    {
        yield return new WaitForSeconds(waitGyroInitializationDuration);
    
        if (SystemInfo.supportsGyroscope)
        {
            initialRotation = transform.rotation;
            Recalibrate();

            gyroRotation.position = transform.position;
            gyroRotation.rotation = transform.rotation;
            GyroEnabled = true;
        }
        else GyroEnabled = false;
        
    }

    private void Update()
    {
        if (InputManager.inputGyro == true)
        {
            if (Time.timeScale == 1 && GyroEnabled)
            {

                ApplyGyroRotation();

                transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation * gyroRotation.rotation, smoothing);
                transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -0.3f, 0.3f), 0.0f, Mathf.Clamp(transform.rotation.z, -0.3f, 0.3f), 1.0f);

            }
        }
        
    }

    private void ApplyGyroRotation()
    {
        offsetRotation = Quaternion.Inverse(gyroInitialRotation) * GyroToUnity(Input.gyro.attitude);

        float currentSpeed = Time.deltaTime * speed;
        Quaternion speedGyroRotation = new Quaternion(
            offsetRotation.x * currentSpeed,
            0f * currentSpeed,
            offsetRotation.y * currentSpeed,
            offsetRotation.w * currentSpeed
        );
        gyroRotation.rotation = speedGyroRotation;
    }

    private Quaternion GyroToUnity(Quaternion gyro)
    {
        return new Quaternion(gyro.x, gyro.y, -gyro.z, -gyro.w);
    }

    public void Recalibrate()
    {
        Quaternion gyro = GyroToUnity(Input.gyro.attitude);
        gyroInitialRotation = gyro;
    }

    void OnGUI()
    {
        if (debug)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = Mathf.RoundToInt(Mathf.Min(Screen.width, Screen.height) / 20f);
            style.normal.textColor = Color.white;
            GUILayout.BeginVertical("box");
            GUILayout.Label("gyroenable: " + Input.gyro.enabled.ToString(), style);
            GUILayout.Label("Attitude: " + Input.gyro.attitude.ToString(), style);
            GUILayout.Label("Rotation: " + transform.rotation.ToString(), style);
            GUILayout.Label("Offset Rotation: " + offsetRotation.ToString(), style);
            GUILayout.Label("Raw Rotation: " + gyroRotation.rotation.ToString(), style);
            GUILayout.EndVertical();
        }
    }
}
