using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
public class AddProcessing : MonoBehaviour
{
    public PostProcessingProfile profile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    Camera[] cameras;
    void Update()
    {
        cameras = GameObject.FindObjectsOfType<Camera>();
        foreach(Camera cam in cameras)
        {
            if (cam.isActiveAndEnabled)
            {
                cam.gameObject.AddComponent<PostProcessingBehaviour>();
                cam.gameObject.GetComponent<PostProcessingBehaviour>().profile = profile;
            }
        }
    }
}
