using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdditionOperation : Operation
{
    public override double Calculate()
    {
        //�����в��������мӷ�����
        return Numbers.Sum();
    }
   
}
