
using UnityEngine;

/// <summary>
/// 指挥者
/// </summary>
public class CarDirector
{
    private CarBuilder _carBuider;
    private GameObject bodyInstance;
   
    //通过构造函数传入具体指挥者
    public CarDirector(CarBuilder carBuider)
    {
        _carBuider = carBuider;
    }
    //构建汽车
    public void ConstructCar()
    {
        _carBuider.BuildBody();//建造车身
    }
    public Car GetCar()
    {
        return _carBuider.GetBuidResult();
    }
}
