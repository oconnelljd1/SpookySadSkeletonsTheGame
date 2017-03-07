using UnityEngine;
using System.Collections;
using UnityEngine.UI; // because we are using the unity UI
using System.Collections.Generic; // for making lists

public class RadarObejct
{
	public Image icon { get; set;} // what icons are on the radar
	public GameObject owner { get; set;} // what game object owns the icon on the radar
}

public class Radar : MonoBehaviour {

	public Transform playerPos; // link in the player so we have them in the center of the radar at all time.
	public float mapScale = 2.0f; // we can increase or decrease the relative distance of the radar objecys from the player

	public static List<RadarObejct> radObjects = new List<RadarObejct>();//using it instead of an array because of not needing to know how large it will be, and it contains other features that are not found in an array

	public static void RegisterRadarObject(GameObject o, Image i)// when the object says that it exists, it runs register radar object, which injects it into the list, and brings the object(owner) and the image
	{
		Image image = Instantiate (i); // the prefab
		radObjects.Add (new RadarObejct (){owner = o, icon = image });// adds to the list
	}

	public static void RemoveRadarObject(GameObject o)// when something in the game goes of the radar (dies, gets picked up, moves out of the view)
	{
		List<RadarObejct> newList = new List<RadarObejct> ();

		for (int i = 0; i < radObjects.Count; i++) // goes through the list looking for the prefab that is destoyed and removes it from the radar
		{
			if(radObjects[i].owner == o)
			{
				Destroy (radObjects [i].icon);
				continue;
			}
			else
				newList.Add(radObjects[i]);
		}

		radObjects.RemoveRange (0, radObjects.Count);
		radObjects.AddRange (newList);
	}

	void DrawRadarDots()// being called in the update, loops through the radar list
	{
		foreach (RadarObejct ro in radObjects) 
		{
			Vector3 radarPos = (ro.owner.transform.position - playerPos.position);// for each object it gets the owners transform position and determines the differece between its postion and the players position
			float distToObject = Vector3.Distance (playerPos.position, ro.owner.transform.position) * mapScale;// works out the angles of the distance between the owner and the player object
			float deltay = Mathf.Atan2 (radarPos.x, radarPos.z) * Mathf.Rad2Deg-270-playerPos.eulerAngles.y;
			// use the folowing in a circle minimap
			//radarPos.x = distToObject * Mathf.Cos (deltay * Mathf.Deg2Rad) * -1;
			//radarPos.z = distToObject * Mathf.Sin (deltay * Mathf.Deg2Rad);

			ro.icon.transform.SetParent (this.transform);
			ro.icon.transform.position = new Vector3 (radarPos.x, radarPos.z, 0) + this.transform.position;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		DrawRadarDots ();
	}
}
