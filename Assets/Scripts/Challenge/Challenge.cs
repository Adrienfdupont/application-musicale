using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    private TextMeshProUGUI _timer;
    private TextMeshProUGUI _dialogBox;
    private Note _playedNote;
    private List<Note> _notes;
    private AudioSource _audioSource;
    private List<GameObject> _answerButtons;
    private TextMeshProUGUI _scoreBox;
    private int _score = 0;
    private float _timeLeft = 90.0f;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _timer = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        _dialogBox = GameObject.Find("AnswerMessage").GetComponent<TextMeshProUGUI>();
        _scoreBox = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _answerButtons = new List<GameObject>()
        {
            GameObject.Find("AnswerButton1"),
            GameObject.Find("AnswerButton2"),
            GameObject.Find("AnswerButton3")
        };
        _notes = NoteManager.getAllNotes();
        
        playOneRound();
    }
    
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            _timer.text = $"{_timeLeft:00.00}";
        }
        else
        {
            _dialogBox.text = "Temps écoulé !";
            for (int i = 0; i < _answerButtons.Count; i++)
            {
                _answerButtons[i].SetActive(false);
            }
        }
    }

    private void playOneRound()
    {
        _playedNote = _notes[Random.Range(0, _notes.Count)];
        _audioSource.clip = _playedNote.getClipAudio();
        _audioSource.Play();
        
        List<Note> pickedNotes = new List<Note>();
        for (int i = 0; i < _answerButtons.Count; i++)
        {
            Note pickedNote;
            while (true)
            {
                pickedNote = _notes[Random.Range(0, _notes.Count)];
                if (!pickedNotes.Contains(pickedNote) && pickedNote != _playedNote)
                {
                    break;
                }
            }
            pickedNotes.Add(pickedNote);
            GameObject button = _answerButtons[i];
            button.SetActive(true);
            button.GetComponentInChildren<TextMeshProUGUI>().text = pickedNote.getFullName();
        }
        
        GameObject correctButton = _answerButtons[Random.Range(0, _answerButtons.Count)];
        correctButton.GetComponentInChildren<TextMeshProUGUI>().text = _playedNote.getFullName();
    }
    
    public void validateAnswer()
    {
        GameObject clickedbutton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        if (clickedbutton.GetComponentInChildren<TextMeshProUGUI>().text == _playedNote.getFullName())
        {
            _score++;
            _scoreBox.text = $"Score: {_score}";
            _dialogBox.GetComponent<TextMeshProUGUI>().text = $"Bravo, la réponse était bien {_playedNote.getFullName()}";
            playOneRound();
        }
        else
        {
            clickedbutton.SetActive(false);
            _dialogBox.GetComponent<TextMeshProUGUI>().text = "Réésayez";
        }
    }
    
    public void replayNote()
    { 
        _audioSource.Play();
    }
}
