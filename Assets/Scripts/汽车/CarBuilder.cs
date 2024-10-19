

using UnityEngine;

public abstract class CarBuilder 
{
    //Ҫ��������յ�
    protected Car _car ;
   
    public abstract void BuildTire();
    public abstract void DestroyTire();
    public abstract void BuildBumber();
    public abstract void DestroyBumper();
    public abstract void BuildLights();
    public abstract void DestroyLights();
    public abstract void BuildBody();
    public abstract void DestroyBody();
    public abstract Car GetBuidResult();//���ؽ�����

    public  CarBuilder()
    {
        //Vector3 carBodyPos = new Vector3(0, 2, 0);
        _car = new Car();
    }
}
