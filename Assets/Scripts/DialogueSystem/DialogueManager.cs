using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text dialogueText;

    [SerializeField] GameObject dialogBox;
    [SerializeField] CharacterMovement player;

    private Queue<string> _sentences;
    private Queue<string> _name;

    // Start is called before the first frame update
    void Start()
    {
        _name = new Queue<string>();
        _sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue dialogue)
    {
        //Make speed of player to zero
        player.playerSpeed = 0;

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
        //Return the player speed
        player.playerSpeed = 5.0f;

        //Make dialog box is inactive
        dialogBox.SetActive(false);

        //Adding Quest Here
    }
}
