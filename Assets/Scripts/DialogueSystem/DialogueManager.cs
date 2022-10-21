using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;
    [SerializeField] int time;

    [SerializeField] GameManager gameManager;
    [SerializeField] TimerManager timerManager;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject popupSuccess;
    [SerializeField] CharacterMovement player;
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] ScoreManager scoreManager;

    public bool isDialogue;

    private Queue<string> _sentences;
    private Queue<string> _name;
    
    void Start()
    {
        _name = new Queue<string>();
        _sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true;

        //Adjust virtual cam
        vCam.m_Lens.FieldOfView = 20;

        //Make player can't move
        player.canMove = false;

        //Make dialog box is active
        dialogBox.SetActive(true);

        //Enqueue the name and sentence
        _name.Clear();

        foreach (string name in dialogue.name)
        {
            _name.Enqueue(name);
        }

        _sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        //Condition if end of sentences
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Dequeue name and sentence
        string names = _name.Dequeue();
        nameText.text = names;

        string sentence = _sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        isDialogue = false;

        //Return field of view value camera
        vCam.m_Lens.FieldOfView = 40;

        //Return canMove variable
        player.canMove = true;

        //Make dialog box is inactive
        dialogBox.SetActive(false);

        if (scoreManager.isAdd)
        {
            popupSuccess.SetActive(true);
        }

        timerManager.timerCount = true;
        timerManager.AddTimer(time);
    }
}
