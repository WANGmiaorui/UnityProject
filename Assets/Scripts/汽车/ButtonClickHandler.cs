using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public X5CarBuilder carBuilder; // ���� X5CarBuilder ʵ��
    public CarData carData; // ���� CarData ʵ��
    private bool isBumperBuilt = false; // ��־����
    private bool isCarBuilt = false; // ��־����
    private bool isLightsBuilt = false; // ��־����
    private bool isTireBuilt = false; // ��־����




    // ������ Awake ���������ڳ�ʼ�� carBuilder
    private void Awake()
    {
       if (carData != null)
        {
            carBuilder = new X5CarBuilder(carData);


        }
        else
        {
            Debug.LogError("CarData reference is not set.");
        }
    }




    // ������������󶨵���ť�ĵ���¼���
    public void OnBuildBumperButtonClick()
    {
        if (carBuilder != null)
        {
            if (!isBumperBuilt)
            {
                // ��һ�ε�����������ո�
                carBuilder.BuildBumber();
                isBumperBuilt = true;
            }
            else
            {
                // �ڶ��ε�������ٱ��ո�
                carBuilder.DestroyBumper();
                isBumperBuilt = false;
            }
        }
        else
        {
            Debug.LogError("X5CarBuilder reference is not set.");
        }
    }
    public void OnBuildBodyButtonClick()
    {
        if (carBuilder != null)
        {
            if (!isCarBuilt)
            {

                carBuilder.BuildBody();
                isCarBuilt = true;
            }
            else
            {
                // �ڶ��ε�������ٱ��ո�
                carBuilder.DestroyBody();
                isCarBuilt = false;
            }
        }
        else
        {
            Debug.LogError("X5CarBuilder reference is not set.");
        }
    } 
    public void OnBuildLightsButtonClick()
    {
        if (carBuilder != null)
        {
            if (!isLightsBuilt)
            {
                // ��һ�ε�����������ո�
                carBuilder.BuildLights();
                isLightsBuilt = true;
            }
            else
            {
                // �ڶ��ε�������ٱ��ո�
                carBuilder.DestroyLights();
                isLightsBuilt = false;
            }
        }
        else
        {
            Debug.LogError("X5CarBuilder reference is not set.");
        }
    } 
    public void OnBuildTireButtonClick()
    {
        if (carBuilder != null)
        {
            if (!isTireBuilt)
            {
                // ��һ�ε�����������ո�
                carBuilder.BuildTire();
                isTireBuilt = true;
            }
            else
            {
                // �ڶ��ε�������ٱ��ո�
                carBuilder.DestroyTire();
                isTireBuilt = false;
            }
        }
        else
        {
            Debug.LogError("X5CarBuilder reference is not set.");
        }
    }

}