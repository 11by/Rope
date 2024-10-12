using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestMiniUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI questNameText;  
    [SerializeField] private TextMeshProUGUI questStatusText; 

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += OnQuestStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= OnQuestStateChange;
    }

    private void Start()
    {
        questNameText.text = "";
        questStatusText.text = "";
    }

    // ����Ʈ ���°� ����� �� ȣ��� �޼���
    private void OnQuestStateChange(Quest quest)
    {

        if (quest.state == QuestState.IN_PROGRESS)
        {
            UpdateQuestUI(quest);
        }
        else if (quest.state == QuestState.FINISHED)
        {
            ClearQuestUI(); 
        }
    }

    // ����Ʈ UI ������Ʈ
    private void UpdateQuestUI(Quest quest)
    {
        questNameText.text = quest.info.displayName;  
        questStatusText.text = quest.GetFullStatusText();  
    }

    private void ClearQuestUI()
    {
        questNameText.text = "";  
        questStatusText.text = "";  
    }
}
