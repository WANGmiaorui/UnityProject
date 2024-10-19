using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 如果使用 UnityEngine.UI
using TMPro; // 如果使用 TextMeshProUGUI

public class OperationManager : MonoBehaviour
{
    public Operation currentOperation;
    public List<double> inputs;
    public List<string> operators;

    // UI 组件
    public Text resultText; // 如果使用 Text 组件
   
    public Button[] numberButtons; // 数字按钮
    public Button[] operatorButtons; // 操作符按钮
    public Button calculateButton; // 计算按钮
    public Button clearButton; // 清除按钮

    public Button pointButton; // 小数点按钮

    public Text errorText; // 异常提醒 使用 Text 组件

    private string currentInput = "";

    void Start()
    {
        // 为每个按钮添加点击事件
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

        // 为小数点按钮添加点击事件
        pointButton.onClick.AddListener(OnDecimalButtonClick);

        // 设置初始显示
        UpdateResultText();
    }

    // 数字按钮点击事件处理
    void OnNumberButtonClick(string numberText)
    {
        // 将点击的数字添加到当前输入的字符串中
        currentInput += numberText;
        // 更新显示
        UpdateResultText();
    }

    // 操作符按钮点击事件处理
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

    // 计算按钮点击事件处理
    void OnCalculateButtonClick()
    {
        if (double.TryParse(currentInput, out double number))
        {
            inputs.Add(number);
        }

        try
        {
            // 先处理乘法和除法
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

            // 再处理加法和减法
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

    // 小数点按钮点击事件处理
    public void OnDecimalButtonClick()
    {
        if (!currentInput.Contains(".")) // 如果当前输入的字符串中不包含小数点
        {
            currentInput += "."; // 添加小数点
            UpdateResultText(); // 更新显示
        }
    }

    // 清除按钮点击事件处理
    void OnClearButtonClick()
    {
        currentInput = "";
        inputs.Clear();
        operators.Clear();
        UpdateResultText();
        ClearError();
    }

    // 更新显示
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

    // 构建显示文本
    string BuildDisplayText()
    {
        if (inputs.Count == 0 && string.IsNullOrEmpty(currentInput))
        {
            return ""; // 如果没有输入，返回空字符串
        }

        string displayText = "";

        for (int i = 0; i < inputs.Count; i++)
        {
            displayText += inputs[i].ToString(); // 将输入的数字转换为字符串并添加到显示文本中
            if (i < operators.Count)
            {
                displayText += " " + operators[i] + " "; // 在数字之间添加当前选择的操作符
            }
        }

        if (!string.IsNullOrEmpty(currentInput))
        {
            if (inputs.Count > 0)
            {
                displayText += " " + currentInput; // 如果有输入的数字，添加当前输入的字符串
            }
            else
            {
                displayText = currentInput; // 如果没有输入的数字，直接显示当前输入的字符串
            }
        }

        return displayText;
    }

    // 执行操作
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
                throw new ArgumentException("无效的操作符");
        }

        if (operation != null)
        {
            operation.Numbers = new List<double> { a, b };
            double result = operation.Calculate();
            Destroy(operation); // 计算完成后销毁组件
            return result;
        }

        throw new ArgumentException("无效的操作符");
    }

    // 显示错误信息
    void ShowError(string message)
    {
        if (errorText != null)
        {
            errorText.text = message;
        }
    }

    // 清除错误信息
    void ClearError()
    {
        if (errorText != null)
        {
            errorText.text = "";
        }
    }
}