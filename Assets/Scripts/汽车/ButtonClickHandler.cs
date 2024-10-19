using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public X5CarBuilder carBuilder; // 引用 X5CarBuilder 实例
    public CarData carData; // 引用 CarData 实例
    private bool isBumperBuilt = false; // 标志变量
    private bool isCarBuilt = false; // 标志变量
    private bool isLightsBuilt = false; // 标志变量
    private bool isTireBuilt = false; // 标志变量




    // 新增的 Awake 方法，用于初始化 carBuilder
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




    // 这个方法将被绑定到按钮的点击事件上
    public void OnBuildBumperButtonClick()
    {
        if (carBuilder != null)
        {
            if (!isBumperBuilt)
            {
                // 第一次点击：创建保险杠
                carBuilder.BuildBumber();
                isBumperBuilt = true;
            }
            else
            {
                // 第二次点击：销毁保险杠
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
                // 第二次点击：销毁保险杠
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
                // 第一次点击：创建保险杠
                carBuilder.BuildLights();
                isLightsBuilt = true;
            }
            else
            {
                // 第二次点击：销毁保险杠
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
                // 第一次点击：创建保险杠
                carBuilder.BuildTire();
                isTireBuilt = true;
            }
            else
            {
                // 第二次点击：销毁保险杠
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