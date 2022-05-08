using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eManager : MonoBehaviour
{
     public List<GameObject> parks_list;
     public List<GameObject> negative_parks_list; 
     public List<GameObject> solar_panel_list;
     public List<GameObject> parksBuy_list;
    [SerializeField]
    main_game_controler gameCompiuter;
    [SerializeField] int tmp_score=0;
    [SerializeField] int solorCounter=0;
    [SerializeField] int parkCounter=0;
    [SerializeField] int truckCounter=0;
    [SerializeField] int OldsolorCounter=0;
    [SerializeField] int OldparkCounter=0;
    [SerializeField] int OldtruckCounter=0;

    // Start is called before the first frame update
    void Awake()
    {
        clearObjects();
    }
    void Start()
    {

        counterUpdate();
        tmp_score = gameCompiuter.score_home();

    } 
    void counterUpdate()
    {
        if (PlayerPrefs.HasKey("solors"))
        {
            solorCounter = PlayerPrefs.GetInt("solors");
        }
        else
        {
            solorCounter = 0;
            PlayerPrefs.SetInt("solors", solorCounter);
        }
        if (PlayerPrefs.HasKey("parks"))
        {
            parkCounter = PlayerPrefs.GetInt("parks");
        }
        else
        {
            parkCounter = 0;
            PlayerPrefs.SetInt("parks", parkCounter);
        }
        if (PlayerPrefs.HasKey("truks"))
        {
            truckCounter = PlayerPrefs.GetInt("truks");
        }
        else
        {
            truckCounter = 0;
            PlayerPrefs.SetInt("truks", truckCounter);
        }
    }
    void sipUpdate()
    {
        if (OldparkCounter!=parkCounter) {
            OldparkCounter = parkCounter;

        }
        if (OldsolorCounter != solorCounter)
        {
            OldsolorCounter = solorCounter;
            solorParks(solorCounter);
        }
        if (OldtruckCounter != truckCounter)
        {
            OldtruckCounter = truckCounter;

        }

    }
     
    void Update()
    {
        if(tmp_score!= gameCompiuter.score_home())
        {
         tmp_score = gameCompiuter.score_home();
            park_live(tmp_score);
        }
        counterUpdate();
        sipUpdate();
    }
    void park_live(int a)
    {
        if (a < -69)
        {
            clearLive();
            if (negative_parks_list[2].activeSelf != true)
            {
                negative_parks_list[2].SetActive(true);
            }
            Debug.Log("-69");
        }
        if (a < -39)
        {
            clearLive();
            if (negative_parks_list[1].activeSelf != true)
            {
                negative_parks_list[1].SetActive(true);
            }
            Debug.Log("-39");
        }
        if (a < -19)
        { clearLive();
            if (negative_parks_list[0].activeSelf != true)
            {
                negative_parks_list[0].SetActive(true);
            }
            Debug.Log("-19");
        }
        if (a > 19)
        {
            clearLive();
            if (parks_list[0].activeSelf != true)
            {
            parks_list[0].SetActive(true);
            }
            Debug.Log("19");
        }
        if (a > 39) {
            clearLive();
            if (parks_list[1].activeSelf != true)
            {
                parks_list[1].SetActive(true);
            }
            Debug.Log("39");
        }
        if (a > 69)
        {
            clearLive();
            if (parks_list[2].activeSelf != true)
            {
                parks_list[2].SetActive(true);
            }
            Debug.Log("69");
        }

    }
    void solorParks(int solor)
    {
        if (solor > solar_panel_list.Count)
        {
    
        }
        else
        {
          for(int y=0; y < solor; y++)
             {
                   solar_panel_list[y].SetActive(true);
             }
        }
        
    }
    void clearLive()
    {
        if (tmp_score == 0)
        {

        }else if (tmp_score>0)
        {
            for (int y = 0; y < negative_parks_list.Count; y++)
            {
                negative_parks_list[y].SetActive(false);
            }
        }else if (tmp_score < 0)
        {
            for (int y = 0; y < parks_list.Count; y++)
            {
                parks_list[y].SetActive(false);
            }
        }



    }
    void buyParks(int a)
    {
        if (parksBuy_list.Count == 0 &&a<= parksBuy_list.Count) { }
        else { 
        for (int y = 0; y < parksBuy_list.Count; y++)
        {
            parksBuy_list[y].SetActive(true);
        } }


    }

    public void ClearParks()
    {
        for (int y = 0; y < parks_list.Count; y++)
        {
            parks_list[y].SetActive(false);
        }
        for (int y = 0; y < parksBuy_list.Count; y++)
        {
            parksBuy_list[y].SetActive(false);
        } 
    }
    public void ClearParksNegative()
    {
        for (int y = 0; y < negative_parks_list.Count; y++)
        {
            negative_parks_list[y].SetActive(false);
        }
    }
    public void OnPositiveParks()
    {
        for (int y = 0; y < solar_panel_list.Count; y++)
        {
            solar_panel_list[y].SetActive(true);
        }
        for (int y = 0; y < parks_list.Count; y++)
        {
            parks_list[y].SetActive(true);
        } 
    }
    public void OnNegativeParks()
    {
        for (int y = 0; y < solar_panel_list.Count; y++)
        {
            solar_panel_list[y].SetActive(true);
        } 
        for (int y = 0; y < negative_parks_list.Count; y++)
        {
            negative_parks_list[y].SetActive(true);
        }
    }
    public void buyParksOn()
    {
        for (int y = 0; y < parksBuy_list.Count; y++)
        {
            parksBuy_list[y].SetActive(true);
        }
    }
    public void buyParksOff()
    {
        for (int y = 0; y < parksBuy_list.Count; y++)
        {
            parksBuy_list[y].SetActive(false);
        }
    }
    public void clearSolors()
    {
        for (int y = 0; y < solar_panel_list.Count; y++)
        {
            solar_panel_list[y].SetActive(false);
        }
    } 
    void clearObjects()
    {
        ClearParks();
        clearSolors();
        ClearParksNegative();
    }
}
