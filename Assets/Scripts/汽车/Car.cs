
using System;
using UnityEngine;
/// <summary>
/// ��Ʒͼֽ
/// </summary>
public class Car
{
    public GameObject CarObject {get;private set;}//����������
 
    // �����ĸ�������
    public Tire Tire { get; set; }//��̥
    public IBumper Bumper { get; set; }//��ײ����
    public IBody Body { get; set; }//����
    public ILights Lights { get; set; }//��ͷ��
   // public IWeapon Weapon { get; set; }//����
/*   public Car(Vector3 carBodyPos)
    {
        CarObject =new GameObject();        
        CarObject.name = "��";
        CarObject.transform.position = carBodyPos;
    } */
    public Car()
    {
        CarObject =new GameObject();        
        CarObject.name = "��";

        CarObject.transform.position = new Vector3(0, 1.5f, 0);
       
    }



}
