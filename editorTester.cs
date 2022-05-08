using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]  
//[ExecuteInEditMode]
[ExecuteInEditMode]
public class editorTester : MonoBehaviour
{
    eManager nuoroda;  
    public enum busena { on, onNegative, off};
    public enum messageUI { on, off };
    public busena dabar;
    public messageUI Pranesimai = messageUI.off;
    public messageUI UIGame = messageUI.off;
    List<GameObject> msgUI;
    [SerializeField] List<Renderer> ListLiveParks = new List<Renderer>();
    [SerializeField] List<Renderer> ListSolarParks;
    [SerializeField] List<Renderer> ListBuyParks;
    [SerializeField] List<Renderer> ListNegativeParks;
    [SerializeField] GameObject parksLive;
    [SerializeField] GameObject solarparksLive;
    [SerializeField] GameObject buyparksLive;
    [SerializeField] GameObject negativeparksLive;
    busena old;
    messageUI oldUI = messageUI.off;
    Transform[] allChildren, solarChilds, buyPChilds, negativeChild;
    List<GameObject> tmp1;
    [SerializeField] Canvas myCanvas;
    void Awake()
    {
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        ListLiveParks = new List<Renderer>();
        ListBuyParks = new List<Renderer>();
        ListSolarParks = new List<Renderer>();
        ListNegativeParks = new List<Renderer>();
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("msg_h");
        msgUI = new List<GameObject>(tmp);
        parksLive= GameObject.Find("park_pool"); 
        allChildren = parksLive.GetComponentsInChildren<Transform>(); 
        tmp1= new List<GameObject>();
        
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].gameObject == null) { }
            else
            { 
                tmp1.Add(allChildren[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            { 
                ListLiveParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        solarparksLive = GameObject.Find("solar_panel_park_1");
        solarChilds = solarparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();
        for (int i = 0; i < solarChilds.Length; i++)
        {
            if (solarChilds[i].gameObject == null) { }
            else
            { 
                tmp1.Add(solarChilds[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListSolarParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        buyparksLive = GameObject.Find("buy_list_parks");
        buyPChilds = buyparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();
        for (int i = 0; i < buyPChilds.Length; i++)
        {
            if (buyPChilds[i].gameObject == null) { }
            else
            {
                tmp1.Add(buyPChilds[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListBuyParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        negativeparksLive = GameObject.Find("negative_park");
        negativeChild = negativeparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();

        for (int i = 0; i < negativeChild.Length; i++)
        {
            if (negativeChild[i].gameObject == null) { }
            else
            {
                tmp1.Add(negativeChild[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListNegativeParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

    }
   


    void Start()
    {
        myCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        ListLiveParks = new List<Renderer>();
        ListBuyParks = new List<Renderer>();
        ListSolarParks = new List<Renderer>();
        ListNegativeParks = new List<Renderer>();
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("msg_h");
        msgUI = new List<GameObject>(tmp);
        parksLive = GameObject.Find("park_pool");
        allChildren = parksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();

        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i].gameObject == null) { }
            else
            {
                tmp1.Add(allChildren[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListLiveParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        solarparksLive = GameObject.Find("solar_panel_park_1");
        solarChilds = solarparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();
        for (int i = 0; i < solarChilds.Length; i++)
        {
            if (solarChilds[i].gameObject == null) { }
            else
            {
                tmp1.Add(solarChilds[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListSolarParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        buyparksLive = GameObject.Find("buy_list_parks");
        buyPChilds = buyparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();
        for (int i = 0; i < buyPChilds.Length; i++)
        {
            if (buyPChilds[i].gameObject == null) { }
            else
            {
                tmp1.Add(buyPChilds[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListBuyParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }

        negativeparksLive = GameObject.Find("negative_park");
        negativeChild = negativeparksLive.GetComponentsInChildren<Transform>();
        tmp1 = new List<GameObject>();

        for (int i = 0; i < negativeChild.Length; i++)
        {
            if (negativeChild[i].gameObject == null) { }
            else
            {
                tmp1.Add(negativeChild[i].gameObject);
            }
        }
        for (int i = 0; i < tmp1.Count; i++)
        {
            if (tmp1[i].GetComponent<Renderer>() == null) { }
            else
            {
                ListNegativeParks.Add(tmp1[i].GetComponent<Renderer>());
            }
        }
        Debug.Log("fine: " + msgUI[0]);
        nuoroda = GameObject.Find("effect_mamager").GetComponent<eManager>(); 
        Debug.Log("is: " + nuoroda);
        old = dabar;
        oldUI = Pranesimai;
    }

    void Update(){  
        if (dabar == old) { }
        else {
          old = dabar;
          ChangeALL();
        }
        if (Pranesimai == oldUI) { }
        else { 
            oldUI = Pranesimai;
            if(Pranesimai == messageUI.on) {
                for (int y = 0; y < msgUI.Count; y++) { msgUI[y].GetComponent<msg_show>().change_sprite(0); } }
            else {
                for (int y = 0; y < msgUI.Count; y++) { msgUI[y].GetComponent<msg_show>().change_sprite(7); } }
        }
        if(UIGame== messageUI.on) {
            if (myCanvas.enabled == true) { }
            else { myCanvas.enabled = true; }
        }
        else{
            if(myCanvas.enabled == false) { }
            else { myCanvas.enabled = false; }
        }
    } 
     
    void ChangeALL() {
        if (dabar == busena.on)  {
            Debug.Log("busena on");
            if (ListLiveParks[0].enabled == false) { LiveParkChanger();  }
            if (ListSolarParks[0].enabled == false) {  LiveSolarParkChanger(); }
            if (ListBuyParks[0].enabled == false)  { LiveBuyParkChanger(); }
            if (ListNegativeParks[0].enabled == true) {  LiveNegativeParkChanger(); }
        }
        else if (dabar == busena.off){
            Debug.Log("busena off");
            if (ListSolarParks[0].enabled == true) {  LiveSolarParkChanger();  }
            if (ListLiveParks[0].enabled == true)  { LiveParkChanger();  } 
            if (ListBuyParks[0].enabled == true) { LiveBuyParkChanger(); }
            if (ListNegativeParks[0].enabled == true)  { LiveNegativeParkChanger(); }
        }
        else if(dabar == busena.onNegative)  {
            Debug.Log("busena on negative");
            if (ListSolarParks[0].enabled == false) {  LiveSolarParkChanger();  } 
            if (ListLiveParks[0].enabled==true) {  LiveParkChanger(); }
            if (ListBuyParks[0].enabled == false) {  LiveBuyParkChanger(); }
            if (ListNegativeParks[0].enabled == false)  { LiveNegativeParkChanger();  }
        }
    } 
    void LiveParkChanger() { 
        for (int y = 0; y < ListLiveParks.Count; y++){ ListLiveParks[y].enabled = !ListLiveParks[y].enabled;  }  }
    void LiveSolarParkChanger() { 
        for (int y = 0; y < ListSolarParks.Count; y++) { ListSolarParks[y].enabled = !ListSolarParks[y].enabled; }}
    void LiveBuyParkChanger() {
        for (int y = 0; y < ListBuyParks.Count; y++) { ListBuyParks[y].enabled = !ListBuyParks[y].enabled; }}
    void LiveNegativeParkChanger()  {
        for (int y = 0; y < ListNegativeParks.Count; y++) {  ListNegativeParks[y].enabled = !ListNegativeParks[y].enabled; }}
    void clearList() {  
        ListLiveParks.Clear();
        ListSolarParks.Clear();
        ListBuyParks.Clear();
        ListNegativeParks.Clear();
    }
    public void enableAllRenders()  {
        for (int y = 0; y < ListLiveParks.Count; y++)   { ListLiveParks[y].enabled = true; }
        for (int y = 0; y < ListSolarParks.Count; y++) {  ListSolarParks[y].enabled = true;  }
        for (int y = 0; y < ListBuyParks.Count; y++)  { ListBuyParks[y].enabled = true;  }
        for (int y = 0; y < ListNegativeParks.Count; y++) {  ListNegativeParks[y].enabled = true;  }
    }
    public void onCanvas() { myCanvas.enabled = true;}
} 