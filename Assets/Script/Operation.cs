using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : MonoBehaviour
{
 
    //操作数列表
    public List<double> Numbers {  get;  set; }=new List<double>();
    //计算结果的抽象方法
    public abstract double Calculate();
}
