using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNote
{
    public AudioClip m_clip{get;}   

    public string m_name {get;}    


    public MusicNote(string name, AudioClip clip)
    {
        m_name = name;
        m_clip = clip;
    }

}