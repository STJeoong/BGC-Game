using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TalkManager talkManager;

    // ��ȭâ
    public GameObject talkPanel;
    public Text UITalkText;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

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
        Debug.Log(talkData);
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