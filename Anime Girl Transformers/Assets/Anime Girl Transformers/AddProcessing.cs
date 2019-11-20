using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using System;
public class AddProcessing : MonoBehaviour
{
    public PostProcessingProfile profile;
    // Start is called before the first frame updat
    Camera[] cameras; 
    void Start()
    {
        cameras = GameObject.FindObjectsOfType<Camera>();
        foreach (Camera cam in cameras)
        {
            if (cam.isActiveAndEnabled)
            {
                cam.gameObject.AddComponent<PostProcessingBehaviour>();
                cam.gameObject.GetComponent<PostProcessingBehaviour>().profile = profile;
            }
        }
    }
    void Update()
    {

    }
}
