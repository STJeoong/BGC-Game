using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{    
    Queue<LineData> lineQueue;
    List<LineData> lineList;
    public int lineIndex = 0;
    void GenerateData()
    {
        lineList.Add(new LineData(1, "???", new string[]{"���̾�, ���ư��� ��"}));
        lineList.Add(new LineData(1, "����", new string[]{"(�ƺ��� �Ͼ�� ���� ��ħ���� ������ ��.)", "(�츮 �ƺ��� �ʹ� �����)"}));

        lineList.Add(new LineData(2, "�ƺ�", new string[]{"���־� ���̴� ������ġ����!"}));
        lineList.Add(new LineData(2, "����", new string[]{"(�ƺ����� ������ġ�� ��������)"}));

        
    }

    void Awake()
    {
        lineQueue = new Queue<LineData>();
        lineList = new List<LineData>();
        GenerateData();
    }

    public void SetLines(int stageNum)
    {
        foreach(LineData line in lineList)
        {
            if(stageNum < line.stageNum)
                break;
            
            if(stageNum == line.stageNum)
            {
                lineQueue.Enqueue(line);
            }
        }
    }
    
    public void ClearLineQueue()
    {
        lineQueue.Clear();
    }

    public string GetLine()
    {          
        if(lineIndex == lineQueue.Peek().lines.Length)
        {
            lineQueue.Dequeue();
            lineIndex = 0;
        }

        if(lineQueue.Count == 0)
        {
            GameManager.Instance.lineNumber++;
            return null;
        }
        
        return lineQueue.Peek().lines[lineIndex];
    }
}
