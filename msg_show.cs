using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class msg_show : MonoBehaviour
{
    public GameObject target, msg_,road_point;  
    private Vector3 point; 
    public SpriteRenderer spriteRenderer;
    public List<Sprite> listSprite;
    public BoxCollider tmpBox;
    public int id;
    void Start()
    { 
        point = target.transform.position;  
    } 
    void Update()
    {
        point = target.transform.position;
        transform.LookAt(point); 
    }
  
    /*
     0 - geltonas plastikas
     1 - melynas popierius
     2 - þalias stiklas  
     3 - popierius ir plastikas
     4 - popierius ir stiklas
     5 - visi
     6 - stiklas ir plastikas
     */
    public void change_sprite(int a)
    {
       
      //  change_a(); update nebereikes
        spriteRenderer.sprite = listSprite[a];
        if (a == 7)
        {
            tmpBox.enabled = false;
        }
        else
        {
            tmpBox.enabled = true;
        }
    }
    public void change_a()
    {
        change_sprite(7);
    }
    
}
