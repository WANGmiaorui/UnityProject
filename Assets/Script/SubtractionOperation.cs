using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubtractionOperation :Operation
{
    public override double Calculate()
    {
        //���������=0���򷵻�0
        if (Numbers.Count == 0) return 0;

        
        double result = Numbers[0];
        //
        for (int i = 1; i < Numbers.Count; i++)
        {
            //������ĵ�һ������ȥ��һ���������
            result -= Numbers[i];
        }
        //�������
        return result;
    }
}
