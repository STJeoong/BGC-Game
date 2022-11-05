using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public int talkIndex = 0;
    void Awake()
    {
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
        talkData.Add(10000 + 1000 + 10, new string[]{"�������� ���� ������ �ִ�."});
        //talkData.Add(10000 + 2000 + 10 + 1, new string[]{"��� ���� ���������� ������ġ�� �Ծ���."});
        
        talkData.Add(20000 + 3000, new string[]{"�ƺ��� å�� ���� �� å���̴�."});
        talkData.Add(20000 + 3000 + 20, new string[]{"�̻��� ������ �׷��� å���� �ִ�."});

        talkData.Add(20000 + 5000, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});
        talkData.Add(20000 + 5000 + 30, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});
    }

    public string GetTalk(int id)
    {
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
