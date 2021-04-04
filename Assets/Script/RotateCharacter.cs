using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    void Update()
    {
        ////moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        ////moveVelocity = moveInput * moveSpeed;

        ////Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        ////Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        ////float rayLength;

        ////if (groundPlane.Raycast(cameraRay, out rayLength))
        ////{
        ////    Vector3 pointToLook = cameraRay.GetPoint(rayLength);
        ////    Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

        ////    transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        ////}

        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        StartCoroutine(Rotate(Vector3.up, 90, 1.0f));
    }

    //IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    //{
    //    Quaternion from = transform.rotation;
    //    Quaternion to = transform.rotation;
    //    to *= Quaternion.Euler(axis * angle);

    //    float elapsed = 0.0f;
    //    while (elapsed < duration)
    //    {
    //        transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }
    //    transform.rotation = to;
    //}
}
