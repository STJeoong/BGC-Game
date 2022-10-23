using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId; // ���� ����Ʈ Id
    public int questOrderIndex; // ����Ʈ ���� ���� �ε���
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("����", new int[]{2000}));
        questList.Add(20, new QuestData("������ �����ϱ�", new int[]{1000, 3000}));
    }

    // Object�� Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ�
    public int GetQuestTalkIndex(int id)
    {
        return questId + questOrderIndex;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }

    public string CheckQuest(int id)
    {   
        if(questList.ContainsKey(questId))
        {
            if(id == questList[questId].objectId[questOrderIndex])
                questOrderIndex++;

            ControlObject();

            if(questOrderIndex == questList[questId].objectId.Length)
                NextQuest();
        
            if(questList.ContainsKey(questId))
                return questList[questId].questName;
        }

        return null;

    }

    void NextQuest()
    {
        questId += 10;
        questOrderIndex = 0;
    }

    void ControlObject()
    {
        switch(questId)
        {
            case 10:
                if(questOrderIndex == 1)
                    questObject[0].SetActive(true);
                break;
            
            case 20:
                if(questOrderIndex == 2)
                    questObject[0].SetActive(false);
                break;
            default:
                break;
        }
    }
}
