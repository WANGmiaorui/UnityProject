using UnityEngine;
//CreateAssetMenu
[CreateAssetMenu(fileName = "New Car Data", menuName = "Car Parts/Car")]
public class CarData : ScriptableObject
{

    public string carName;        // ��������

    public GameObject carBodyPrefab;  //����
    public Vector3 carBodyPos;//����λ��

    public GameObject carBumperPrefab;  //���ո�
    public Vector3 carBumperPos;  //���ո�

    public GameObject tireLPrefab;//����̥
    public Vector3[] tiresLPositions = new Vector3[2];

    public GameObject tireRPrefab;//����̥
    public Vector3[] tiresRPositions = new Vector3[2];

    public GameObject carLightPrefab;//��ͷ��
    public Vector3 carLightPos;//��ͷ��
   
   // public Vector3 carBodyPos=Vector3.zero;//����λ��

   
    



}