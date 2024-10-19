using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ���ʹ�� UnityEngine.UI
using TMPro; // ���ʹ�� TextMeshProUGUI

public class OperationManager : MonoBehaviour
{
    public Operation currentOperation;
    public List<double> inputs;
    public List<string> operators;

    // UI ���
    public Text resultText; // ���ʹ�� Text ���
   
    public Button[] numberButtons; // ���ְ�ť
    public Button[] operatorButtons; // ��������ť
    public Button calculateButton; // ���㰴ť
    public Button clearButton; // �����ť

    public Button pointButton; // С���㰴ť

    public Text errorText; // �쳣���� ʹ�� Text ���

    private string currentInput = "";

    void Start()
    {
        // Ϊÿ����ť��ӵ���¼�
        foreach (var button in numberButtons)
        {
            button.onClick.AddListener(() => OnNumberButtonClick(button.GetComponentInChildren<Text>().text));
        }

        foreach (var button in operatorButtons)
        {
            button.onClick.AddListener(() => OnOperatorButtonClick(button.GetComponentInChildren<Text>().text));
        }

        calculateButton.onClick.AddListener(OnCalculateButtonClick);
        clearButton.onClick.AddListener(OnClearButtonClick);

        // ΪС���㰴ť��ӵ���¼�
        pointButton.onClick.AddListener(OnDecimalButtonClick);

        // ���ó�ʼ��ʾ
        UpdateResultText();
    }

    // ���ְ�ť����¼�����
    void OnNumberButtonClick(string numberText)
    {
        // �������������ӵ���ǰ������ַ�����
        currentInput += numberText;
        // ������ʾ
        UpdateResultText();
    }

    // ��������ť����¼�����
    void OnOperatorButtonClick(string operatorText)
    {
        if (double.TryParse(currentInput, out double number))
        {
            inputs.Add(number);
            currentInput = "";
            operators.Add(operatorText);
        }
        UpdateResultText();
    }

    // ���㰴ť����¼�����
    void OnCalculateButtonClick()
    {
        if (double.TryParse(currentInput, out double number))
        {
            inputs.Add(number);
        }

        try
        {
            // �ȴ���˷��ͳ���
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == "*" || operators[i] == "/")
                {
                    double result = PerformOperation(inputs[i], inputs[i + 1], operators[i]);
                    inputs[i] = result;
                    inputs.RemoveAt(i + 1);
                    operators.RemoveAt(i);
                    i--;
                }
            }

            // �ٴ���ӷ��ͼ���
            double finalResult = inputs[0];
            for (int i = 0; i < operators.Count; i++)
            {
                finalResult = PerformOperation(finalResult, inputs[i + 1], operators[i]);
            }

            inputs.Clear();
            operators.Clear();
            currentInput = finalResult.ToString();
            UpdateResultText();
        }
        catch (DivideByZeroException ex)
        {
            ShowError(ex.Message);
        }
        catch (ArgumentException ex)
        {
            ShowError(ex.Message);
        }
    }

    // С���㰴ť����¼�����
    public void OnDecimalButtonClick()
    {
        if (!currentInput.Contains(".")) // �����ǰ������ַ����в�����С����
        {
            currentInput += "."; // ���С����
            UpdateResultText(); // ������ʾ
        }
    }

    // �����ť����¼�����
    void OnClearButtonClick()
    {
        currentInput = "";
        inputs.Clear();
        operators.Clear();
        UpdateResultText();
        ClearError();
    }

    // ������ʾ
    void UpdateResultText()
    {
        if (resultText != null)
        {
            resultText.text = BuildDisplayText();
        }
        /* else if (resultTextPro != null)
         {
             resultTextPro.text = BuildDisplayText();
         }*/
    }

    // ������ʾ�ı�
    string BuildDisplayText()
    {
        if (inputs.Count == 0 && string.IsNullOrEmpty(currentInput))
        {
            return ""; // ���û�����룬���ؿ��ַ���
        }

        string displayText = "";

        for (int i = 0; i < inputs.Count; i++)
        {
            displayText += inputs[i].ToString(); // �����������ת��Ϊ�ַ�������ӵ���ʾ�ı���
            if (i < operators.Count)
            {
                displayText += " " + operators[i] + " "; // ������֮����ӵ�ǰѡ��Ĳ�����
            }
        }

        if (!string.IsNullOrEmpty(currentInput))
        {
            if (inputs.Count > 0)
            {
                displayText += " " + currentInput; // �������������֣���ӵ�ǰ������ַ���
            }
            else
            {
                displayText = currentInput; // ���û����������֣�ֱ����ʾ��ǰ������ַ���
            }
        }

        return displayText;
    }

    // ִ�в���
    double PerformOperation(double a, double b, string op)
    {
        Operation operation;

        switch (op)
        {
            case "+":
                operation = gameObject.AddComponent<AdditionOperation>();
                break;
            case "-":
                operation = gameObject.AddComponent<SubtractionOperation>();
                break;
            case "*":
                operation = gameObject.AddComponent<MultiplicationOperation>();
                break;
            case "/":
                operation = gameObject.AddComponent<DivisionOperation>();
                break;
            default:
                throw new ArgumentException("��Ч�Ĳ�����");
        }

        if (operation != null)
        {
            operation.Numbers = new List<double> { a, b };
            double result = operation.Calculate();
            Destroy(operation); // ������ɺ��������
            return result;
        }

        throw new ArgumentException("��Ч�Ĳ�����");
    }

    // ��ʾ������Ϣ
    void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
        }
    }

    // ���������Ϣ
    void ClearError()
    {
        if (errorText != null)
        {
            errorText.text = "";
        }
    }
}