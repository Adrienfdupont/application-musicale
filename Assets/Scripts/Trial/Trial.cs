using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class Trial : MonoBehaviour
{
    private SpriteRenderer _background;
    private TextMeshProUGUI _noteText;
    private AudioSource _audioSource;
    private List<Note> _notes;
    void Start()
    {
        _background = GameObject.Find("NoteBox").GetComponent<SpriteRenderer>();
        _noteText = GameObject.Find("NoteText").GetComponent<TextMeshProUGUI>();
        _audioSource = GetComponent<AudioSource>();
        _notes = NoteManager.getAllNotes();
        
        _background.GetComponent<SpriteRenderer>().color = Color.black;
        _noteText.text = "";
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (Note note in _notes)
            {
                if (Input.GetKeyDown(note.getKeyCode()))
                {
                    changeNote(note);
                    break;
                }
            }
        }
    }

    private void changeNote(Note note)
    {
        _audioSource.clip = note.getClipAudio();
        _audioSource.Play();
        
        Color newColor;
        if (ColorUtility.TryParseHtmlString(note.getColor(), out newColor))
        {
            _background.color = newColor;
        }
        _noteText.text = note.getFullName();
    }
}
