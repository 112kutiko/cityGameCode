using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_cam_control : MonoBehaviour
{
    [Header("gameobject all")]
    public GameObject target; 
    [Header("main varbles")]
    [SerializeField] private float speedMod = 150.0f;
    [SerializeField] private Vector3 point;
    [Header("phone varbles")]
    [SerializeField] Vector2 startPosition;
    [SerializeField] Vector2 endPosition; 
      
    void Start()
    {
        point = target.transform.position; 
        transform.LookAt(point); 
    }
     
    void Update()
    {
        if (main_game_controler.controls.ControlerGame.getLive() == true) {
           
            if (Application.isMobilePlatform == false)
        {
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
}