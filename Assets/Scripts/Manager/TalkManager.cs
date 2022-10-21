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
        // x000 : ��������
        // x00 : ������Ʈ
        talkData.Add(1000, new string[]{"�ξ�", "����� ������ ������ �ִ� ���̴�."});
        talkData.Add(2000, new string[]{"�ƺ� ����", "����� å ������ �ִ� ���̴�."});
    }

    public string GetTalk(int objectId, int talkIndex)
    {
        if(talkIndex == talkData[objectId].Length)
            return null;
        else
            return talkData[objectId][talkIndex];
    }

}
