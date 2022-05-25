using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav_go : MonoBehaviour
{
    public static nav_go controls { set; get; }
    Vector3 destination;
    NavMeshAgent agent;
    bool progress=false;
    public List<GameObject> truck_list;
    [SerializeField] private int ids = 0;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controls = this; 
    } 
    void Update()
    { 
        if (progress==true) { if (_distance() > 1f)  {   }  else
            {   
                progress = false; 
                main_game_controler.controls.selected_tag_list[0].GetComponent<house_holder>().check_by_ids(ids);
                main_game_controler.controls.selected_tag_list.Remove(main_game_controler.controls.selected_tag_list[0]);
                for (int i=0;i<5000;i++) { }
                Debug.Log("counter done");
                main_game_controler.controls.ControlerGame.setTravel(false);
            } }
    }
    public void go_to(Transform target_now)
    {
        if (progress != true)  {
        progress = true;
        agent.destination = target_now.position;
        }     
    } 
    public void reset_trucks()
    {
        for(int i = 0; i < truck_list.Count-1; i++)
        {
            truck_list[i].SetActive(false);
        } 
        truck_list[ids].SetActive(true);  
    }
    public void show_truck()
    {  
       
        if (ids == truck_list.Count)
        {
            main_game_controler.controls.ControlerGame.setTrucksDone(true);
            ids = 0 ;
        }
        Debug.Log("id show: " + ids);
        reset_trucks();

         
    } 
    public void resetIds(int a) { ids+= a; }
   public int getIDS() { return ids; }
    public float _distance() // gra=ina atstuma
    {
        return Vector3.Distance(transform.position, agent.destination);
    }
}
