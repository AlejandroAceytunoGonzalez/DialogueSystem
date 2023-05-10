using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueSystemDisplay textDisplay;
    [SerializeField] private DialogueSystemDisplay optionsDisplay;
    [SerializeField] private string knotName;
    [SerializeField] private List<ChoiceEvent> choiceEvents;
    public void DialogueStart()
    {
        DialogueCanvas.Instance.StartDialogue(knotName,textDisplay,optionsDisplay,choiceEvents);
    }
}
