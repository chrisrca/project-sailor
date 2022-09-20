using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camerafollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public Vector3 camcoords = new Vector3();
    public GameObject mainCamera;
    public GameObject player;
    public MovementController script;

    void Start() 
    {
        mainCamera.transform.position = camcoords;
    }

    void Update()
    {
        Vector3 playerposition = script.CameraCoordinates + offset;    
        mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, playerposition, ref velocity, smoothTime);
    }
}
