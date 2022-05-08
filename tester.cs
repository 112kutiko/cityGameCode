using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class tester : MonoBehaviour
{

    public GameObject shop_ui;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (main_game_controler.controls.shop_btn.activeSelf==true || main_game_controler.controls.pauze_meniu.activeSelf == false || main_game_controler.controls.ControlerGame.getLive() == true)
            {   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1500))
            {    if (hit.transform.name == "shop")
                    {
                        main_game_controler.controls.new_gen();
                        shop_ui.SetActive(!shop_ui.activeSelf);
                        if (main_game_controler.controls.ControlerGame.getTravel() == false)
                        {
                        main_game_controler.controls.shop_btn.SetActive(!main_game_controler.controls.shop_btn.activeSelf);
                        }

                        return;
                    }


                if (hit.transform.parent.tag =="msg_h" && hit.transform.parent.tag!=null)
                { 
                    main_game_controler.controls.selected_tag_list.Add(hit.transform.parent.GetComponent<msg_show>().road_point);
                    hit.transform.parent.GetComponent<msg_show>().change_a();
                        return;
                }
                             }
            }
            else
            {
                Debug.Log("erro by ui");
            }
          
        }
    }

    public bool ShopOn()
    {
        if (shop_ui.activeSelf == true) { return true; } else { return false; }
   //     if (shop_ui == null) { return true; }
    }
    public void IsButtonCan()
    {
        if (main_game_controler.controls.ControlerGame.getTravel() == false)
        {
            main_game_controler.controls.shop_btn.SetActive(true);
        }
    }
}
