using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���彨����
/// </summary>
public class X5CarBuilder : CarBuilder
{
    private CarData _carData;//��ȡ������������
    private List<GameObject> leftTires = new List<GameObject>();
    private List<GameObject> rightTires = new List<GameObject>();
    //ͨ�����캯����������
    public X5CarBuilder(CarData carData)
    {
        _carData = carData;
    }
    public override void BuildBody()
    {
        //ʵ��������
        GameObject bodyInstance = Object.Instantiate(_carData.carBodyPrefab);
        bodyInstance.name = "CarBody";
        //���ø�����
        bodyInstance.transform.SetParent(_car.CarObject.transform);
        //���ó���λ��(���Ը���ʵ������������λ��,�����CarData�����ò���ȡ��
        bodyInstance.transform.localPosition = _carData.carBodyPos;
        //�������������󲢸�ֵ��Car���е�Body�ֶ�
         _car.Body =new Body(bodyInstance);
       
    }
    public override void DestroyBody()
    {
        //��������Ķ���
        GameObject.Destroy(_car.Body.GetBodyPrefab());
    }
    public override void BuildBumber()
    {
        //ʵ��������
        GameObject carBumperInstance = Object.Instantiate(_carData.carBumperPrefab);
        carBumperInstance.name = "CarBumper";
        //���ø�����
        carBumperInstance.transform.SetParent(_car.CarObject.transform);
        //���ó���λ��(���Ը���ʵ������������λ��,�����CarData�����ò���ȡ��
        carBumperInstance.transform.localPosition = _carData.carBodyPos;
        //�������������󲢸�ֵ��Car���е�Body�ֶ�
        _car.Bumper = new Bumper(carBumperInstance);

    }
    public override void DestroyBumper()
    {
        //��������Ķ���
        GameObject.Destroy(_car.Bumper.GetBumperPrefab());
    }

    public override void BuildLights()
    {
        //ʵ��������
        GameObject carLightsInstance = Object.Instantiate(_carData.carLightPrefab);
        carLightsInstance.name = "CarLights";
        //���ø�����
        carLightsInstance.transform.SetParent(_car.CarObject.transform);
        //���ó���λ��(���Ը���ʵ������������λ��,�����CarData�����ò���ȡ��
        carLightsInstance.transform.localPosition = _carData.carBodyPos;
        //�������������󲢸�ֵ��Car���е�Body�ֶ�
        _car.Lights = new Lights(carLightsInstance);
    }
    public override void DestroyLights()
    {
        //��������Ķ���
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
        /*        // �����������̥
                if (_car != null && _car.Tire != null)
                {
                    GameObject.Destroy(_car.Tire.GetTireLPrefab());
                    GameObject.Destroy(_car.Tire.GetTireRPrefab());
                }*/

        // ɾ����������̥
        foreach (var tire in leftTires)
        {
            GameObject.Destroy(tire);
        }
        leftTires.Clear();

        // ɾ����������̥
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
