using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour//NOTE: This script has been updated to V2 after video recording
{
    Plane plane;
    Camera camera;
    float scrollSpeed = 20;

    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        float mousePosX = Input.GetAxis("Mouse X");
        float mousePosY = Input.GetAxis("Mouse Y");

         

        if (Input.touchCount > 0)
        {
            plane.SetNormalAndPosition(transform.up, transform.position);
            var Delta1 = Vector3.zero;
            Delta1 = PlanePositionDelta(Input.GetTouch(0));
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                camera.transform.Translate(Delta1, Space.World);
            } 


        }

        //if (Input.GetMouseButton(0))
        //{
            
        //    if (mousePosX > 0)
        //    {
        //        transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime * mousePosX, Space.World);
        //    }
        //    if (mousePosX < 0)
        //    {
        //        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime * mousePosX, Space.World);
        //    }
        //    if (mousePosY > 0)
        //    {
        //        transform.Translate(Vector3.forward * -scrollSpeed * Time.deltaTime * mousePosY, Space.World);
        //    }
        //    if (mousePosY < 0)
        //    {
        //        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime * mousePosY, Space.World);
        //    }

        //}

        if(Input.touchCount > 1)
        {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World);
        }
    }
    protected Vector3 PlanePositionDelta(Touch touch)
    {
        //not moved
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        //delta
        var rayBefore = camera.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = camera.ScreenPointToRay(touch.position);
        if (plane.Raycast(rayBefore, out var enterBefore) && plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

        //not on plane
        return Vector3.zero;
    }
}



