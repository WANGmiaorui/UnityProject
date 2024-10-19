using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 轮胎类，解决轮胎的存储问题
/// </summary>
public class Tire : ITire
{
    public GameObject letfTire { get; private set; }

    public GameObject rightTire { get; private set; }
  
   
    public Tire(GameObject letfTire, GameObject rightTire)
    {
        this.letfTire = letfTire;
        this.rightTire = rightTire;
    }

/*    public float GetGripLevel()
    {
        return 1f;
    }*/

/*    public int GetPrice()
    {
        return 15000;
    }*/

    public GameObject GetTireLPrefab(List<GameObject> leftTires)
    {
        //return letfTire;
        return leftTires.Count > 0 ? leftTires[0] : null;
    }


    public GameObject GetTireRPrefab(List<GameObject> rightTires)
    {
        return rightTires.Count > 0 ? rightTires[0] : null;
    }

   
}
