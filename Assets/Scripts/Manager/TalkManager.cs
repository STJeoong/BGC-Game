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
        talkData.Add(0, new string[]{"�̼��� �����ϼ���"});

        talkData.Add(10000, new string[]{"�ξ�"});
        talkData.Add(20000, new string[]{"�ƺ� ����"});
        talkData.Add(30000, new string[]{"��Ź��"});

        talkData.Add(60000, new string[]{"����"});

        talkData.Add(10000 + 1000, new string[]{"�������� ���� ������ �ִ�."});
        talkData.Add(10000 + 1000 + 10, new string[]{"�������� ���� ������ �ִ�."});
        talkData.Add(10000 + 2000 + 10 + 1, new string[]{"��� ���� ���������� ������ġ�� �Ծ���."});
        
        talkData.Add(20000 + 3000, new string[]{"�ƺ��� å�� ���� �� å���̴�."});
        talkData.Add(20000 + 3000 + 20, new string[]{"�̻��� ������ �׷��� å���� �ִ�."});
        talkData.Add(20000 + 4000 + 20 + 1, new string[]{"������ �̻��� �����̴�."});

        talkData.Add(20000 + 5000, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});
        talkData.Add(20000 + 5000 + 30, new string[]{"�ƺ��� �Բ� �ִ� �����̴�."});
        talkData.Add(20000 + 6000 + 20 + 1, new string[]{"�ƺ��� ������ ���⸦ ��� �ִ�."});
        
        
    }

    public string GetTalk(int id, int talkIndex)
    {
        Debug.Log(id);
        // ����Ʈ id���� ����Ʈ index�� �ش��ϴ� ��簡 ���� ���
        if(!talkData.ContainsKey(id))
        {
            // �⺻ ��� ���
            if(!talkData.ContainsKey(id - id%10))
            {
                return GetTalk(id - id%100, talkIndex);
            }
                
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
