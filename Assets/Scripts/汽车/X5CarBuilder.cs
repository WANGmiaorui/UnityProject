using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 具体建造者
/// </summary>
public class X5CarBuilder : CarBuilder
{
    private CarData _carData;//读取汽车部件数据
    private List<GameObject> leftTires = new List<GameObject>();
    private List<GameObject> rightTires = new List<GameObject>();
    //通过构造函数传进数据
    public X5CarBuilder(CarData carData)
    {
        _carData = carData;
    }
    public override void BuildBody()
    {
        //实例化车身
        GameObject bodyInstance = Object.Instantiate(_carData.carBodyPrefab);
        bodyInstance.name = "CarBody";
        //设置父物体
        bodyInstance.transform.SetParent(_car.CarObject.transform);
        //设置车身位置(可以根据实际需求来调整位置,例如从CarData中配置并读取）
        bodyInstance.transform.localPosition = _carData.carBodyPos;
        //创建车身部件对象并赋值给Car类中的Body字段
         _car.Body =new Body(bodyInstance);
       
    }
    public override void DestroyBody()
    {
        //消除建造的东西
        GameObject.Destroy(_car.Body.GetBodyPrefab());
    }
    public override void BuildBumber()
    {
        //实例化车身
        GameObject carBumperInstance = Object.Instantiate(_carData.carBumperPrefab);
        carBumperInstance.name = "CarBumper";
        //设置父物体
        carBumperInstance.transform.SetParent(_car.CarObject.transform);
        //设置车身位置(可以根据实际需求来调整位置,例如从CarData中配置并读取）
        carBumperInstance.transform.localPosition = _carData.carBodyPos;
        //创建车身部件对象并赋值给Car类中的Body字段
        _car.Bumper = new Bumper(carBumperInstance);

    }
    public override void DestroyBumper()
    {
        //消除建造的东西
        GameObject.Destroy(_car.Bumper.GetBumperPrefab());
    }

    public override void BuildLights()
    {
        //实例化车身
        GameObject carLightsInstance = Object.Instantiate(_carData.carLightPrefab);
        carLightsInstance.name = "CarLights";
        //设置父物体
        carLightsInstance.transform.SetParent(_car.CarObject.transform);
        //设置车身位置(可以根据实际需求来调整位置,例如从CarData中配置并读取）
        carLightsInstance.transform.localPosition = _carData.carBodyPos;
        //创建车身部件对象并赋值给Car类中的Body字段
        _car.Lights = new Lights(carLightsInstance);
    }
    public override void DestroyLights()
    {
        //消除建造的东西
        GameObject.Destroy(_car.Lights.GetLightsPrefab());
    }

    public override void BuildTire()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject tire = Object.Instantiate(_carData.tireLPrefab);
            tire.name = "CartireL";
            tire.transform.SetParent(_car.CarObject.transform);
            tire.transform.position = _carData.tiresLPositions[i];
            leftTires.Add(tire);
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject tire = Object.Instantiate(_carData.tireRPrefab);
            tire.name = "CartireR";
            tire.transform.SetParent(_car.CarObject.transform);
            tire.transform.position = _carData.tiresRPositions[i];
            rightTires.Add(tire);
        }
    }
    public override void DestroyTire()
    {
        /*        // 消除建造的轮胎
                if (_car != null && _car.Tire != null)
                {
                    GameObject.Destroy(_car.Tire.GetTireLPrefab());
                    GameObject.Destroy(_car.Tire.GetTireRPrefab());
                }*/

        // 删除所有左轮胎
        foreach (var tire in leftTires)
        {
            GameObject.Destroy(tire);
        }
        leftTires.Clear();

        // 删除所有右轮胎
        foreach (var tire in rightTires)
        {
            GameObject.Destroy(tire);
        }
        rightTires.Clear();
    }

    public override Car GetBuidResult()   
    {
       return _car;
    }
}
