using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemDisplay : MonoBehaviour
{
    [SerializeField] private string dialogueTitle;
    [SerializeField] private string dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Transform optionParent;
    [SerializeField] private Button optionPrefab;
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void setImage(Sprite image)
    {
        dialogueImage.sprite = image;
    }
    public void setTitle(string title)
    {
        dialogueText = title;
    }
    public void setText(string dialogue)
    {
        dialogueText = dialogue;
    }
    public void CreateOptions(List<Choice> choices)
    {
        foreach (Choice choice in choices)
        {
            Button button = Instantiate(optionPrefab, optionParent);
        }
    }
}
