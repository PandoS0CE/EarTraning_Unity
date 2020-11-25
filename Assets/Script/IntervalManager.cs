using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;



public class IntervalManager : MonoBehaviour
{
    #region Variables
    
    private Dictionary<int, MusicNote> m_playableNotes = new Dictionary<int, MusicNote>();
    private AudioSource m_MyAudioSource;


    // int past_first_note = 0;
    // int past_second_note = 0;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        initNotes();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void initNotes()
    {  
        string path = "Sound/Piano/mp3_Notes/";
        m_playableNotes.Add(0, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"c3")));
        m_playableNotes.Add(1, new MusicNote("Do#", Resources.Load<AudioClip>(path+"c-3")));
        m_playableNotes.Add(2, new MusicNote("Re", Resources.Load<AudioClip>(path+"d3")));
        m_playableNotes.Add(3, new MusicNote("Re#", Resources.Load<AudioClip>(path+"d-3")));
        m_playableNotes.Add(4, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"e3")));
        m_playableNotes.Add(5, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"f3")));
        m_playableNotes.Add(6, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"f-3")));
        m_playableNotes.Add(7, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"g3")));
        m_playableNotes.Add(8, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"g-3")));
        m_playableNotes.Add(9, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"a4")));
        m_playableNotes.Add(10, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"a-4")));
        m_playableNotes.Add(11, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"b4")));
        m_playableNotes.Add(12, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"c4")));
    }

    public void playNote(AudioClip noteclip)
    {
        m_MyAudioSource.PlayOneShot(noteclip);   
    }

    public void genInterval()
    {
        StartCoroutine(playInterval());
        
        
        //On get les deux notes de l'intervale
        int first_note = Random.Range(0, 8);
        int second_note = 0;

        do
        {
            second_note = Random.Range(0, 8);
        }
        while(second_note == first_note);

        int intervale = Mathf.Abs(second_note - first_note);

        Debug.Log("First Note : " + first_note + " Seconde Note : " + second_note + "Interval : " + intervale);

    }

    public IEnumerator playInterval()
    {
        foreach(var key in m_playableNotes.Keys)
        {
            playNote(m_playableNotes[key].m_clip);
            yield return new WaitUntil(() => m_MyAudioSource.isPlaying == false);
        }
       
    }
}
