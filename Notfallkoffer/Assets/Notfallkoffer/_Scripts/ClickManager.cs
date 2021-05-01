using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    string platform = "pc";
    // public static Camera mainCam;

    public Camera cam;
    public float maxCameraOffset = 200f;
    public float startX;
    private Vector3 startPoint;
    private bool isHeldDown;

    // Start is called before the first frame update
    void Start()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            platform = "phone";
        }

        maxCameraOffset = 200f;

        startX = cam.transform.position.x;

       // mainCam = Camera.
    }

    // Update is called once per frame
    void Update()
    {

        if(isHeldDown == false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                startPoint = mousePos;
                
                isHeldDown = true;
            }
        }
        if (isHeldDown == true)
        {   Vector3 draggedPos = Input.mousePosition;
            //draggedPos = Camera.main.ScreenToWorldPoint(draggedPos);

           // Debug.Log(draggedPos.x);

            float x = startPoint.x - draggedPos.x;
            Debug.Log(cam.gameObject.transform.position.x);
            Debug.Log(-1f * maxCameraOffset);
            Debug.Log(cam.gameObject.transform.position.x >= -maxCameraOffset);
            //Debug.Log(cam.gameObject.transform.position.x <= startX + maxCameraOffset);

            if (cam.gameObject.transform.position.x >= -maxCameraOffset && cam.gameObject.transform.position.x <= maxCameraOffset)
            {
                cam.gameObject.transform.Translate(x * 20f * Time.deltaTime, 0, 0);
            }
          
            if(cam.gameObject.transform.position.x < -maxCameraOffset)
            {
                cam.gameObject.transform.position = new Vector3(-maxCameraOffset + 1f, cam.gameObject.transform.position.y, cam.gameObject.transform.position.z);
            }
            if (cam.gameObject.transform.position.x > maxCameraOffset)
            {
                cam.gameObject.transform.position = new Vector3(maxCameraOffset - 1f, cam.gameObject.transform.position.y, cam.gameObject.transform.position.z);
            }


        }

        if (Input.GetMouseButtonDown(0))
            {

                Ray ray = CreateRay();
                RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction, Mathf.Infinity);

                if (hit == true)
                {

                    GameObject hitObj = hit.transform.gameObject;

                    if (hitObj != null)
                    {
                        //Debug.Log(hit.transform.name);

                        string selectableTag = "Ballon";
                        if (hitObj.transform.CompareTag(selectableTag))
                        {
                            //Debug.Log("balloon hit");
                            GameObject baloonCat = hit.transform.parent.GetComponentInParent<Transform>().gameObject;

                            //Debug.Log(baloonCat);

                            Destroy(baloonCat, .5f);
                        }
                    }

                }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isHeldDown = false;
        }


    }

    private void OnMouseDown()
    {
     //   if(Input.GetMouseButtonDown(0))
      //  {
            Vector3 mousePos = Input.mousePosition;
           mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPoint = mousePos;

            isHeldDown = true;
        //}
       
    }

    private void OnMouseUp()
    {
        isHeldDown = false;
    }
    private static Ray CreateRay()
    {
      return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}

