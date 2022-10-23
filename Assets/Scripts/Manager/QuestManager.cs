using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        questList.Add(10, new QuestData("������ġ �����", new int[]{1000, 2000}));
        questList.Add(20, new QuestData("å �迭", new int[]{3000, 4000}));
        questList.Add(30, new QuestData("�� �̱�", new int[]{5000, 6000}));
    
    }

    public void SetQuestClear(int questid)
    {
        questList[questId].cleared = true;
    }

    // Object�� Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ�
    public int GetQuestTalkIndex()
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

            bool clear = questList[questId].cleared;
            if(questOrderIndex == questList[questId].objectId.Length && clear)
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
                    
                    Debug.Log("Stage1_Puzzle ����");
                    //GameManager.Instance.ChangeNextScene("Stage1_Puzzle");
                break;
            
            case 20:
                if(questOrderIndex == 1)
                    Debug.Log("Stage2_Puzzle1 ����");
                    //GameManager.Instance.ChangeNextScene("Stage2_Puzzle1");
                break;
            case 30:
                if(questOrderIndex == 1)
                {
                    Debug.Log("Stage2_Puzzle2 ����");
                    GameManager.Instance.ChangeNextScene("Stage2_Puzzle2");
                }
                    
                if(questOrderIndex == 2)
                {
                    Debug.Log("Stage2 ����");
                    GameManager.Instance.ChangeNextScene("Stage2");
                }
                break;
            default:
                break;
        }
    }
}
