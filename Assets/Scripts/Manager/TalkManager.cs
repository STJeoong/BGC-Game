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
        //  x000 : ������Ʈ - scanObject���� ������
        //   x0 : ����Ʈ - QuestManager���� ������
        talkData.Add(1000, new string[]{"�ξ�"});
        talkData.Add(2000, new string[]{"�ƺ� ����"});
        talkData.Add(3000, new string[]{"����"});

        talkData.Add(1000 + 10, new string[]{"�ξ�", "����� ������ ������ �ִ� ���̴�."});
        talkData.Add(2000 + 10, new string[]{"�ƺ� ����", "����� å ������ �ִ� ���̴�."});

        talkData.Add(1000 + 20, new string[]{"������ ���� ���� ���� ���ȴ�.", "������ ������ Ǯ������Ұ� ����.", "������ ���� ������ ��Ƽ ����", "Ư���� �ҽ� �����", "ġ�� ��Ŭ ���� �����"});
        
        talkData.Add(3000 + 20 + 1, new string[]{"���踦 ã�Ҵ�."});
        
        talkData.Add(2000 + 30, new string[]{"���� �����̴�", "������ ���� ����� ������ ���.", "���忡 ������ �ִ�?"});
    }

    public string GetTalk(int id, int talkIndex)
    {
        // ����Ʈ id���� ����Ʈ index�� �ش��ϴ� ��簡 ���� ���
        if(!talkData.ContainsKey(id))
        {
            // �⺻ ��� ���
            if(!talkData.ContainsKey(id - id%10))
                return GetTalk(id - id%100, talkIndex);
            else
                return GetTalk(id - id%10, talkIndex);
            
        }

        // ����Ʈ id���� ����Ʈ index�� �ش��ϴ� ��簡 �ִ� ���
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    
}
