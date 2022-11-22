using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId; // ���� ����Ʈ Id
    Dictionary<int, QuestData> questList;
    public GameObject[] questObject;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("������ġ �����", new int[]{1000}));
        questList.Add(20, new QuestData("������ġ �ǳ��ֱ�", new int[]{2000}));
        questList.Add(30, new QuestData("å �迭", new int[]{3000}));
        questList.Add(40, new QuestData("�� �̱�", new int[]{5000}));
    }

    public void SetQuestClear(int questid)
    {
        questList[questId].cleared = true;
    }

    // Object�� Id�� �޾� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ�
    public int GetQuestTalkIndex()
    {
        return questId;
    }

    public string CheckQuest()
    {
        if(questList.ContainsKey(questId))
        {
            ControlObject();

            if(questList[questId].cleared)
                NextQuest();
            
            if(questList.ContainsKey(questId))
                return questList[questId].questName;
        }

        return null;
    }

    void NextQuest()
    {
        questId += 10;
    }

    void ControlObject()
    {
        PuzzleTrigger puzzleTrigger;
        QuestTrigger questTrigger;
        switch(questId)
        {
            case 10:
                questList[questId].cleared = true;
                GameManager.Instance.SetLineQueue();
                GameManager.Instance.Action(null);
                questObject[1].SetActive(true);
                GameManager.Instance.limitStage = 20000;
                GameManager.Instance.doorManager.SetActivate();
                puzzleTrigger = questObject[0].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                Inventory.Instance.Insert("Sandwich");
                break;
            case 20:
                questList[questId].cleared = true;
                Debug.Log("������ġ �ƾ�");
                questObject[1].SetActive(false);
                questTrigger = questObject[1].GetComponent<QuestTrigger>();
                questTrigger.isActivate = false;
                GameManager.Instance.globalLight.SetIntensity(0.4f);
                GameManager.Instance.globalLight.SetColor(new Color32(178, 158, 255, 255));
                questObject[2].SetActive(true);
                break;
            case 30:
                questList[questId].cleared = true;
                GameManager.Instance.doorManager.SetActivate();
                puzzleTrigger = questObject[3].GetComponent<PuzzleTrigger>();
                puzzleTrigger.Restore();
                puzzleTrigger.isActivate = false;
                break;
            default:
                break;
        }
    }
}