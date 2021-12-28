using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    [SerializeField] private float rotatespeed = 10f;
    private Vector2 StartPosition;
    private Vector2 directionPosition;
    private Quaternion rotationObject;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    rotationObject = Quaternion.Euler(touch.deltaPosition.y * rotatespeed * Time.deltaTime, 0f , -touch.deltaPosition.x * rotatespeed * Time.deltaTime);
                    transform.rotation = rotationObject * transform.rotation;
                    transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -0.3f, 0.3f), 0.0f, Mathf.Clamp(transform.rotation.z, -0.3f, 0.3f), 1.0f);
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }
    }
}
