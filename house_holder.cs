using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house_holder : MonoBehaviour
{

    //public string name;
    public int green = 0, yellow = 0, blue = 0;
    public bool is_collectable = true;
    public int score_g = 1;
    public int ids = 0;
    public GameObject msg_show=null;
    List<GameObject> temp;
    void Start()
    {
          temp = new List<GameObject>(GameObject.FindGameObjectsWithTag("msg_h"));

        if (is_collectable == true) { 
            for (int o=0;o< temp.Count;o++)
            {
                if (temp[o].GetComponent<msg_show>().id == ids) { msg_show = temp[o];
                    msg_show.GetComponent<msg_show>().change_sprite(7);
                    msg_show.GetComponent<msg_show>().road_point = gameObject;
                    break;
                }
            }
            temp.Clear();
            }
         

    }
    public void stats_change(int g, int y, int b)
    {
        
        green =g; yellow = y; blue = b; 
        if(g!=0 && y == 0 && b == 0)
        {
         msg_show.GetComponent<msg_show>().change_sprite(2);
        }
        else if (g == 0 && y != 0 && b == 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(0);
        }
        else if (g == 0 && y == 0 && b != 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(1);
        }
        else if (g == 0 && y != 0 && b != 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(3);
        }
        else if (g != 0 && y == 0 && b != 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(4);
        }
        else if (g != 0 && y != 0 && b == 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(6);
        }
        else if (g != 0 && y != 0 && b != 0)
        {
            msg_show.GetComponent<msg_show>().change_sprite(5);
        }
         
    }
    public void stats_update()
    { 
        msg_show.SetActive(!gameObject.activeSelf);
    }
    public void reset_toZero()
    { 
        green = 0; 
        yellow = 0; 
        blue = 0;
    }
    public bool empty_or_not()
    {
        if(green == 0 && yellow == 0 && blue == 0)
        { 
            return true;
        }
        else { return false; }
    }
    public Vector3 myStore() {
        Vector3 a = new Vector3(green, yellow, blue);
        return a;
    }
    public void check_by_ids(int i)
    {
        if (is_collectable)
        {

            if (i == 0)
            {
                if (green != 0)
                {
                    main_game_controler.controls.set_score(score_g);
                    green = 0;
                }
                else
                {
                    main_game_controler.controls.set_score(-score_g);
                }
            }
            else if (i == 1)
            {
                if (yellow != 0)
                {
                    main_game_controler.controls.set_score(score_g);
                    yellow = 0;
                }
                else
                {
                    main_game_controler.controls.set_score(-score_g);
                }
            }
            else if (i == 2)
            {
                if (blue != 0)
                {
                    main_game_controler.controls.set_score(score_g);
                    blue = 0;
                }
                else
                {
                    main_game_controler.controls.set_score(-score_g);
                }

            }
        } 
    }

}
