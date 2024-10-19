using UnityEngine;
//CreateAssetMenu
[CreateAssetMenu(fileName = "New Car Data", menuName = "Car Parts/Car")]
public class CarData : ScriptableObject
{

    public string carName;        // 汽车名称

    public GameObject carBodyPrefab;  //车身
    public Vector3 carBodyPos;//车身位置

    public GameObject carBumperPrefab;  //保险杠
    public Vector3 carBumperPos;  //保险杠

    public GameObject tireLPrefab;//左轮胎
    public Vector3[] tiresLPositions = new Vector3[2];

    public GameObject tireRPrefab;//右轮胎
    public Vector3[] tiresRPositions = new Vector3[2];

    public GameObject carLightPrefab;//车头灯
    public Vector3 carLightPos;//车头灯
   
   // public Vector3 carBodyPos=Vector3.zero;//车身位置

   
    



}