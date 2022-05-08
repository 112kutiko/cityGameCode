using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class gameManager
{
	[SerializeField] bool is_live = false;
	[SerializeField] bool is_travel = false;
	[SerializeField] bool is_pause = false;
	[SerializeField] bool is_generateOn = false; 
	[SerializeField] bool is_done = false;
	[SerializeField] bool start_per = false;
	[SerializeField] bool truck_done = false;
	[SerializeField] bool refresh_update = false;

	public gameManager()
    {
		is_live = false;
		is_travel = false;
		is_pause = false;
		is_generateOn = false;
	}
	public gameManager(bool a, bool b,bool c,bool f)
	{
		is_live = a;
		is_travel = b;
		is_pause = c;
		is_generateOn = f;
	}
	public gameManager(List<bool> a)
	{
		is_live = a[0];
		is_travel = a[1];
		is_pause = a[2];
		is_generateOn = a[3];
	} 

	public void setUpdate(bool a) { refresh_update = a; }
	public void setLive(bool sender ) { is_live = sender;   }
	public void setTravel(bool a ) { is_travel = a; }
	public void setPause(bool a ) { is_pause = a; }
	public void setGenerator(bool a) { is_generateOn = a; } 
	public void setStart(bool a) { start_per = a; }
	public void setDone(bool a) { 	is_done = a; }
	public void setTrucksDone(bool a) 	{ truck_done = a; }

	public bool getLive() { return is_live; }
	public bool getTravel() { return is_travel; }
	public bool getPause() { return is_pause; }
	public bool getGenerator() { return is_generateOn; } 
	public bool getStart() { return start_per; }
	public bool getDone() { return is_done; }
	public bool getTrucks() { return truck_done; }
	public bool getUpdate() { return refresh_update; }
 
 
}