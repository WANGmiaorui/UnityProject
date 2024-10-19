
using UnityEngine;

/// <summary>
/// ָ����
/// </summary>
public class CarDirector
{
    private CarBuilder _carBuider;
    private GameObject bodyInstance;
   
    //ͨ�����캯���������ָ����
    public CarDirector(CarBuilder carBuider)
    {
        _carBuider = carBuider;
    }
    //��������
    public void ConstructCar()
    {
        _carBuider.BuildBody();//���쳵��
    }
    public Car GetCar()
    {
        return _carBuider.GetBuidResult();
    }
}
