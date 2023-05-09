using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueTitle;
    [SerializeField] private TextMeshProUGUI dialogueText;
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
        dialogueTitle.text = title;
    }
    public void setText(string dialogue)
    {
        dialogueText.text = dialogue;
    }
    public void CreateOptions(List<Choice> choices)
    {
        foreach (Choice choice in choices)
        {
            Button button = Instantiate(optionPrefab, optionParent);
        }
    }
}
