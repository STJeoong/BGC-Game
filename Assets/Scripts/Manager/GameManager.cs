using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public int stageNumber;
    public QuestManager questManager;
    public TalkManager talkManager;

    // ��ȭâ
    public GameObject talkPanel;
    public Text UITalkText;
    public GameObject scanObject;
    public bool isAction = false;
    public int talkIndex;

    public void Start()
    {
        talkPanel.SetActive(isAction);
        questManager.CheckQuest();
        stageNumber = 10000;
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id);

        //��ȭâ Ȱ��ȭ ���¿� ���� ��ȭâ Ȱ��ȭ ����
        talkPanel.SetActive(isAction); 
    }

    void Talk(int id)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        UITalkText.text = talkData;
        
        isAction = true;
        talkIndex++;
    }


}