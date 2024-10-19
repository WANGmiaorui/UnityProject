using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationOperation : Operation
{
    public override double Calculate()
    {
        double result = 1;
        foreach(var number in Numbers)
        {
            result *= number;
        }
        return result;
    }
}
