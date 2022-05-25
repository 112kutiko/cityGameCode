using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class main_game_controler : MonoBehaviour
{
    public static main_game_controler controls { set; get; }
    [Header("main ui and gameobject")]
    public Slider RedSlider;
    public Slider GreenSlider;
    public GameObject  start_btn;
    public GameObject pauze_meniu;
    public Text MText;
    public Text countText;
    public List<GameObject> player_tag_list;
    public List<GameObject> selected_tag_list;
    public gameManager ControlerGame;
    [Header("varbles")]  
    [SerializeField]
    private int my_score=0;
    [SerializeField]
    private int money;
    [SerializeField]
    private int my_house = 10; 
    public int my_generate_test; 
    public Coroutine travell_=null; 

    [SerializeField] bool pauze;

    [Header("timer")]
    float currenttime = 0f;
    [SerializeField] float timeGspeed = 2f;
    [SerializeField] float startingtime=30f;
    [Header("shop")]
    public GameObject shop_btn;
    public GameObject shop_table;
    public Text moneyText;

    [SerializeField] tester mainTester;
    void Awake()
    {
     editorTester eTest = GameObject.Find("EDITOR TESTER").GetComponent<editorTester>();
     eTest.enableAllRenders();
     eTest.onCanvas();
    }
    void Start()
    {
       
        currenttime = startingtime;
        controls = this;
        silders();
        mainTester = gameObject.GetComponent<tester>();
        ControlerGame = new gameManager();
        ControlerGame.setLive(true);
        ControlerGame.setGenerator(true);
        nav_go.controls.show_truck();
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            money = 0;
            PlayerPrefs.SetInt("Money", money);
        }
        Time.timeScale = timeGspeed;
    }
    void update2()// klavi6ai
    {
        /*if (Input.GetKey(KeyCode.Escape))
        {
            
            if (shop_table.activeSelf == true)
            {
            }
            else
            {
                if (pauze == false)
                {
                    pauze_meniu.SetActive(true);
                       pauze = !pauze;
                    PauseGame();
                }
                else
                {
                    pauze_meniu.SetActive(false);
                    pauze = !pauze;
                    ResumeGame();
                }
            }
           
             
        
        }*/
      
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("________________");
            Debug.Log("truck id: "+nav_go.controls.getIDS());
            Debug.Log("----------------");
        }
        shopUpdate();
    }
    public void shopUpdate()
    {
        moneyText.text = "" + PlayerPrefs.GetInt("Money");
        MText.text =""+ PlayerPrefs.GetInt("Money");
    }



    // Update is called once per frame
    void Update()
    {
        update2();
        shopUpdate();
        if (shop_table.activeSelf == true)
        {
            PauseGame();
        } 
        if(mainTester.ShopOn() == false && ControlerGame.getLive() == true && travell_ == null && GetComponent<MainTutorial>().tutorialPanel.activeSelf==false)
        {
            currenttime -= 1 * Time.deltaTime; 
            countText.text = currenttime.ToString("0");
            if (currenttime <=0)
            {
              
                currenttime = startingtime;
                start_travel();
                start_btn.SetActive(false);
                shop_btn.SetActive(false);
            }

        }

        if (ControlerGame.getGenerator() ==true && ControlerGame.getLive()==true)
        { 
            ControlerGame.setGenerator(false);
            generate_(); 
            Debug.Log("generuoja");
            start_btn.SetActive(true);

        } 
        if (ControlerGame.getStart() && ControlerGame.getLive() == true)
        {
            if (travell_ == null)
            {
                hide_not_selected();
                travell_ = StartCoroutine(go_to_road());
                ControlerGame.setStart(false); 
                Debug.Log("juda");
               
                countText.text = " ";
                currenttime = startingtime;
            }

        } 
         if (ControlerGame.getUpdate() && ControlerGame.getLive() == true)
        {

            ControlerGame.setUpdate(false);
            Debug.Log("atnaujina"); 
            check_houses();
            if (ControlerGame.getGenerator() == false)
            {
              reOnMsg();
              
            }
            shop_btn.SetActive(true);
            ControlerGame.setLive(true);
           ControlerGame.setDone(false);  
        }  


        if (ControlerGame.getTrucks() == true && ControlerGame.getLive() == true )
           {
            ControlerGame.setTrucksDone(false);
            Debug.Log("done");
            trashCount();
            hide_not_selected();
            new_gen(); 
            ControlerGame.setLive(true);
            ecoAdd();
        }
        shopUpdate();

    }
    public void ecoAdd()
    {
        float t = (PlayerPrefs.GetInt("solors")/10);
        float a = (PlayerPrefs.GetInt("parks")/10);
        int u = (int)(t + a);
        if ((1 * u) >0.3)
        {
        my_score += u;
        }
        Debug.Log("eco: "+ u);
        silders();
    }
    public void start_travel()
    {
       
        ControlerGame.setStart(true);
        selected_tag_list.Add(player_tag_list[0]); 
 
    }  
    public void silders()
    {
        if (my_score == 0)
        {
            RedSlider.value = my_score;
            GreenSlider.value = my_score;
        }else if (my_score < 0)
        {
            RedSlider.value = -my_score;
            GreenSlider.value = 0f;
        }else if (my_score >0)
        {
            RedSlider.value = 0f;
            GreenSlider.value = my_score;
        } 
    }    
    public void set_score(int i)
    {
        Debug.Log("points: " + i);
        my_score += i; 
        silders();
        if (CheckScore(i))
        {
            addMoney(i*2);
        }
    }
    public void generate_() {
        int tmp_house = 0;
        int tmp_house_select = Random.Range(0, 10);
        house_holder linkUse;
        while (tmp_house < my_house)
        { if (tmp_house != my_house) { 
                    for (int i=0;i< player_tag_list.Count; i++){
                        linkUse = player_tag_list[i].GetComponent<house_holder>();
                             if (2< tmp_house_select && tmp_house_select < 9){
                                    if(linkUse.is_collectable == true){
                                             if(linkUse.green==0 && linkUse.yellow == 0 && linkUse.blue == 0) {
                                             Vector3 tmp_vec = generated_numbers();
                                             linkUse.stats_change((int)tmp_vec.x, (int)tmp_vec.y, (int)tmp_vec.z); 
                                             tmp_house++; 
                                             my_generate_test = tmp_house; 
                                             }   }  }
                             if(tmp_house == my_house){ break;  }
                             tmp_house_select = Random.Range(0, 10);
                    }  }else{  break;  }  } 
    }
    public Vector3 generated_numbers()
    {
        int tmp_ = Random.Range(0, 10);
        int tmp_1 = Random.Range(0, 10);
        int tmp_2 = Random.Range(0, 10);
        if (tmp_2 < 5){ tmp_2 = 0; }
        if (tmp_1 < 5) {  tmp_1 = 0;}
        if (tmp_ < 5) { tmp_ = 0;  }
        Vector3 myVector = new Vector3(tmp_, tmp_1, tmp_2);
        return myVector;
    } 
    public void check_houses()
    { 
        bool laikinas1 = true; 
        for (int i=0;i< player_tag_list.Count;i++)
        {
            if (player_tag_list[i].GetComponent<house_holder>().empty_or_not() == false) { 
                laikinas1 = false;
                break;
            }
            

        }       
        ControlerGame.setGenerator(laikinas1); 
    }
    public void reOnMsg()
    {
        for (int i = 0; i < player_tag_list.Count; i++)
        {
            if (player_tag_list[i].GetComponent<house_holder>().empty_or_not() == true)
            { 
            }else
              { 
                Vector3 a = player_tag_list[i].GetComponent<house_holder>().myStore();
                player_tag_list[i].GetComponent<house_holder>().stats_change((int)a.x, (int)a.y, (int)a.z);
                } 
        }  
        new_gen(); 
    } 
    IEnumerator go_to_road()
    {
        
        while(selected_tag_list.Count!=0 )
        {
            if(selected_tag_list.Count == 0|| selected_tag_list.Count < 0)
            { }
            else
            { 
            nav_go.controls.go_to(selected_tag_list[0].transform);
            ControlerGame.setTravel(true);
            }
          
            yield return new WaitUntil(() => ControlerGame.getTravel() == false);
        } 
        travell_ = null;
        
       ControlerGame.setDone(true); 
        ControlerGame.setUpdate(true);
        nav_go.controls.resetIds(1);
        nav_go.controls.show_truck();
    }
    public void new_gen()
    { 
        if(ControlerGame.getTravel() != true)
        { 
        start_btn.SetActive(!start_btn.activeSelf);
        ControlerGame.setLive(!ControlerGame.getLive());
    }
    }
    public void trashCount()
    {
        int sc = 0;
        for(int i=0; i < player_tag_list.Count; i++)
        {
            if (player_tag_list[i].GetComponent<house_holder>().empty_or_not() == false)
            {
                sc--;
                player_tag_list[i].GetComponent<house_holder>().reset_toZero();
                Debug.Log("-1 point praleistas");
            }
        }
        if (sc < 0) { set_score(sc); 
        }
        else if (sc == 0) { addMoney(20); }
ControlerGame.setGenerator(true);
    }   
    public void hide_not_selected()
    { 
        for (int i = 0; i < player_tag_list.Count; i++)
        {
           /// debug
         // Debug.Log(player_tag_list[i].name);
                    if(player_tag_list[i].GetComponent<house_holder>().is_collectable == true) {
                if (player_tag_list[i].GetComponent<house_holder>().msg_show != null) {
                  if(player_tag_list[i].GetComponent<house_holder>().msg_show.GetComponent<msg_show>().spriteRenderer.sprite != player_tag_list[i].GetComponent<house_holder>().msg_show.GetComponent<msg_show>().listSprite[7])
                    {
                        player_tag_list[i].GetComponent<house_holder>().msg_show.GetComponent<msg_show>().change_sprite(7);
                    }
                }
                  } 
         
        }
    }
    public int score_home() { return my_score; }
    public void addMoney(int m) {
        money += m;
        PlayerPrefs.SetInt("Money", money);
    }
    public bool CheckScore(int t)
    {
        if (t == 0) { return true; }
        else if (t > 0) { return true; }
        else if (t < 0) { return false; }
        return false;
    }
    public void addParks()
    {
        if (money >= 350)
        {
            money -= 350;
            AddValue(1, "parks");
            PlayerPrefs.SetInt("Money", money);
        }
        shopUpdate();
    }
    public void addSolor()
    {
        if (money >= 200)
        {
            money -= 200;
        AddValue(1, "solor");
            PlayerPrefs.SetInt("Money", money);
        }
        shopUpdate();

    }
    public void AddValue(int s, string t)
    {
        switch (t)
        {
            case "solor":
                PlayerPrefs.SetInt("solors", PlayerPrefs.GetInt("solors") + s); 
                break;
            case "parks":
                PlayerPrefs.SetInt("parks", PlayerPrefs.GetInt("parks") + s); 
                break; 
            default:
                Debug.Log("error to adds");
                break;
        }
    }
 
   

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = timeGspeed;
    }
    public void exsitGame()
    {
        Application.Quit();
    }


}