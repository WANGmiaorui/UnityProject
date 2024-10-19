using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubtractionOperation :Operation
{
    public override double Calculate()
    {
        //如果操作数=0，则返回0
        if (Numbers.Count == 0) return 0;

        
        double result = Numbers[0];
        //
        for (int i = 1; i < Numbers.Count; i++)
        {
            //用输入的第一个数减去下一个输入的数
            result -= Numbers[i];
        }
        //返沪结果
        return result;
    }
}
