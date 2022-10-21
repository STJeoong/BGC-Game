using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public QuestManager questManager;
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
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        UITalkText.text = talkData;
        
        isAction = true;
        talkIndex++;
    }


}