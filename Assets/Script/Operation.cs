using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : MonoBehaviour
{
 
    //�������б�
    public List<double> Numbers {  get;  set; }=new List<double>();
    //�������ĳ��󷽷�
    public abstract double Calculate();
}
