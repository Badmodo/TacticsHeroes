using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    ////to have the health bars orientate on an angle towards the camera
    //void Update()
    //{
    //    transform.LookAt(Camera.main.transform.position, -Vector3.up);
    //}

    //to keep them on the same rotation on the y
    private void LateUpdate()
    {
        transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
    }
}
