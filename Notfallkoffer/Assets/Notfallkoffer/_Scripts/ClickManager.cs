using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    string platform = "pc";
    // public static Camera mainCam;

    public Camera cam;
    public float maxCameraOffset = 200f;
    public float startX;
    private Vector3 startPoint;
    private bool isHeldDown;
    private float dragspeed = 10.5f;


    public Slider slider;

    public float sliderCurrVal = 0f;
    public float sliderMaxVal = 1000f;


    private int combo = 1;
    private float baseProgress = 3f;

    public ColorManager colorManager;


    void Start()
    {
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            platform = "phone";
        }

        slider.maxValue = sliderMaxVal;

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
           // Debug.Log(cam.gameObject.transform.position.x);
            //Debug.Log(-1f * maxCameraOffset);
            //Debug.Log(cam.gameObject.transform.position.x >= -maxCameraOffset);
            //Debug.Log(cam.gameObject.transform.position.x <= startX + maxCameraOffset);

            if (cam.gameObject.transform.position.x >= -maxCameraOffset && cam.gameObject.transform.position.x <= maxCameraOffset)
            {
                cam.gameObject.transform.Translate(x * dragspeed * Time.deltaTime, 0, 0);
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
                            string currColor = colorManager.currentColor;
//                            Debug.Log(hit.transform.parent.GetComponent<BallonLerper>().ballon.color);
//                            Debug.Log(currColor);
//                            Debug.Log(hit.transform.parent.GetComponent<BallonLerper>().ballon.color.Equals(currColor));

                            if (hit.transform.parent.GetComponent<BallonLerper>().ballon.color.Equals(currColor))
                            {
                                combo += 1;
                            }
                            else
                            {
                                combo = 1;
                            }

                            IncrementProgress(baseProgress);

                            //Debug.Log("balloon hit");
                            GameObject baloonCat = hit.transform.parent.GetComponentInParent<Transform>().gameObject;

                            //Debug.Log(baloonCat);
                            hit.transform.parent.GetComponent<BallonLerper>().particleSystem.Play();
                            Destroy(baloonCat, .5f);
                            WimmelSoundManager.instance.PlaySource("Luftballon platzen");
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

    public void IncrementProgress(float newProgress)
    {
        //Debug.Log((newProgress * combo));
        slider.value += (newProgress * combo) ;

    }

}

