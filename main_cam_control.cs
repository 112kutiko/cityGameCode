using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_cam_control : MonoBehaviour
{
    [Header("gameobject all")]
    public GameObject target, zoom; 
    [Header("main varbles")]
    [SerializeField] private float speedMod = 150.0f;
    [SerializeField] private Vector3 point;
    [Header("phone varbles")]
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition;
    [SerializeField] float mainZoom = 60f;
    [SerializeField] float outZoom = 33.2f;
    void Start()
    {
        point = target.transform.position; 
        transform.LookAt(point);
        if (Application.isMobilePlatform == true)
        { zoom.SetActive(true); }
        else { zoom.SetActive(false); }
        }
     
    void Update()
    {
        if (main_game_controler.controls.ControlerGame.getLive() == true) {
           
            if (Application.isMobilePlatform == false)
        {
                if (Input.GetKeyDown(KeyCode.Z)){
                    zoomC();

                }

                    if (Input.mouseScrollDelta.y == 0)
            { }
            else if (Input.mouseScrollDelta.y > 0)
            {
                right_();     
            }
            else
            {
                left_();
            }
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            { 
                startPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPosition = Input.GetTouch(0).position; 
                if (startPosition.x < endPosition.x)
                {
                   
                    right_();
                }
                if (startPosition.x > endPosition.x)
                {
                    left_();
                }
            } 
        }
    }
    }
    void left_()
    {
        transform.RotateAround(target.transform.position, Vector3.up, speedMod * Time.deltaTime);
    }
    void right_()
    {
        transform.RotateAround(target.transform.position, Vector3.down, speedMod * Time.deltaTime);
    }
    public void zoomC()
    {
        float isNow = transform.gameObject.GetComponent<Camera>().fieldOfView;
        if (isNow == outZoom)
        {
            transform.gameObject.GetComponent<Camera>().fieldOfView = mainZoom;
        }
        else
        {
            transform.gameObject.GetComponent<Camera>().fieldOfView = outZoom;
        }
    }
}