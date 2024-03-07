using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public static class NoteManager
    {
        public static List<Note> getAllNotes()
        {
            List<Note> _notes = new List<Note>();
            _notes.Add(new Note(KeyCode.Q, "C", "Do", "#7C85F2"));
            _notes.Add(new Note(KeyCode.S, "D", "Re", "#AF3B6E"));
            _notes.Add(new Note(KeyCode.D, "E", "Mi", "#424651"));
            _notes.Add(new Note(KeyCode.F, "F", "Fa", "#21FA90"));
            _notes.Add(new Note(KeyCode.G, "G", "Sol", "#ACAD94"));
            _notes.Add(new Note(KeyCode.H, "A", "La", "#D8D4D5"));
            _notes.Add(new Note(KeyCode.J, "B", "Si", "#384D48"));
            
            return _notes;
        }
    }
}