
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DivisionOperation : Operation
{
    public override double Calculate()
    {
        // 如果没有操作数，就返回0
        if (Numbers.Count == 0) return 0;

        // 如果只有一个操作数，返回该操作数
        if (Numbers.Count == 1) return Numbers[0];

        double result = Numbers[0];

        // 从第二个数开始检查，确保除数不为0
        for (int i = 1; i < Numbers.Count; i++)
        {
            if (Numbers[i] == 0)
            {
                // 在 UI 中显示错误信息
                // 你可以在这里添加代码来处理 UI 更新
                throw new DivideByZeroException("除数不能为零。");
            }
            result /= Numbers[i];
        }

        return result;
    }
}
