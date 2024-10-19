using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdditionOperation : Operation
{
    public override double Calculate()
    {
        //对所有操作数进行加法运算
        return Numbers.Sum();
    }
   
}
