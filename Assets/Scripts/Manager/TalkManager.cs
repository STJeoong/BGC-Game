using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    List<int> talkIds;
    Dictionary<int, string[]> talkData;
    public int talkIndex = 0;
    void Awake()
    {
        talkIds = new List<int>();
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //  x000 : ������Ʈ - scanObject���� ������
        //   x0 : ����Ʈ - QuestManager���� ������
        talkData.Add(0, new string[]{"�̼��� �����ϼ���"});

        talkData.Add(10000, new string[]{"�ξ�"});
        talkData.Add(20000, new string[]{"�ƺ� ����"});
        talkData.Add(30000, new string[]{"��Ź��"});

        talkData.Add(60000, new string[]{"����"});

        talkData.Add(10000 + 1000, new string[]{"���������̴�."});
        talkData.Add(10000 + 1000 + 20, new string[]{"�������� ���� ������ �ִ�."});
        
        talkData.Add(20000 + 1000, new string[]{"�ƺ��� å�� ���� �� å���̴�."});
        talkData.Add(20000 + 1000 + 20, new string[]{"�̻��� ������ �׷��� å���� �ִ�."});

        talkData.Add(20000 + 2000, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});
        talkData.Add(20000 + 2000 + 30, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});

        foreach(int key in talkData.Keys)
            talkIds.Add(key);
    }

    public string GetTalk(int id)
    {
        if(!(talkIds.Contains(id) || talkIds.Contains(id - id%10) || talkIds.Contains(id - id%100)))
            return null;
        // ����Ʈ id���� ����Ʈ index�� �ش��ϴ� ��簡 ���� ���
        if(!talkData.ContainsKey(id))
        {
            // �⺻ ��� ���
            if(!talkData.ContainsKey(id - id%10))
            {
                return GetTalk(id - id%100);
            }
                
            else
                return GetTalk(id - id%10);
        }

        // ����Ʈ id���� ����Ʈ index�� �ش��ϴ� ��簡 �ִ� ���
        if(talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
