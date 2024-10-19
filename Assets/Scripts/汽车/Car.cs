
using System;
using UnityEngine;
/// <summary>
/// 产品图纸
/// </summary>
public class Car
{
    public GameObject CarObject {get;private set;}//汽车根对象
 
    // 汽车的各个部件
    public Tire Tire { get; set; }//轮胎
    public IBumper Bumper { get; set; }//防撞横梁
    public IBody Body { get; set; }//车壳
    public ILights Lights { get; set; }//车头灯
   // public IWeapon Weapon { get; set; }//武器
/*   public Car(Vector3 carBodyPos)
    {
        CarObject =new GameObject();        
        CarObject.name = "车";
        CarObject.transform.position = carBodyPos;
    } */
    public Car()
    {
        CarObject =new GameObject();        
        CarObject.name = "车";

        CarObject.transform.position = new Vector3(0, 1.5f, 0);
       
    }



}
