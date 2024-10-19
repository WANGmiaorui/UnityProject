
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DivisionOperation : Operation
{
    public override double Calculate()
    {
        // ���û�в��������ͷ���0
        if (Numbers.Count == 0) return 0;

        // ���ֻ��һ�������������ظò�����
        if (Numbers.Count == 1) return Numbers[0];

        double result = Numbers[0];

        // �ӵڶ�������ʼ��飬ȷ��������Ϊ0
        for (int i = 1; i < Numbers.Count; i++)
        {
            if (Numbers[i] == 0)
            {
                // �� UI ����ʾ������Ϣ
                // �������������Ӵ��������� UI ����
                throw new DivideByZeroException("��������Ϊ�㡣");
            }
            result /= Numbers[i];
        }

        return result;
    }
}
