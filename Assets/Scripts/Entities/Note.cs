using UnityEditor;
using UnityEngine;

public class Note
{
    private KeyCode _keyCode;
    private string _name;
    private string _fullName;
    private AudioClip _clipAudio;
    private string _color;

    public Note(KeyCode keyCode, string name, string fullName, string color)
    {
        _keyCode = keyCode;
        _name = name;
        _fullName = fullName;
        _color = color;
        _clipAudio = AssetDatabase.LoadAssetAtPath<AudioClip>($"Assets/piano-mp3/{_name}3.mp3");
    }
    
    public KeyCode getKeyCode()
    {
        return _keyCode;
    }
    
    public string getName()
    {
        return _name;
    }
    
    public string getFullName()
    {
        return _fullName;
    }
    
    public AudioClip getClipAudio()
    {
        return _clipAudio;
    }
    
    public string getColor()
    {
        return _color;
    }
}