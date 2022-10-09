using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(100, new string[]{"�ֹ��̴�.", "�������.", "���� �������"});
        talkData.Add(300, new string[]{"�ƺ��� �׷��� ���������̴�.", "�� ���������� ������ �ִ°���?"});
    }

    public string GetTalk(int objectId, int talkIndex)
    {
        if(talkIndex == talkData[objectId].Length)
            return null;
        else
            return talkData[objectId][talkIndex];
    }

}
