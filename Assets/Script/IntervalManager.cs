using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;



public class IntervalManager : MonoBehaviour
{
    #region Variables
    
    private Dictionary<int, MusicNote> m_playableNotes = new Dictionary<int, MusicNote>();
    private Dictionary<int, string> m_intervals = new Dictionary<int, string>();
    private AudioSource m_MyAudioSource;

    public Text text_reponse;


    // int past_first_note = 0;
    // int past_second_note = 0;

    #endregion

    void Awake()
    {
        initNotes();
        initIntervals();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Init les noms des intervalles par rapport à l'écart
    public void initIntervals()
    {
        m_intervals.Add(1, "SecondeMin");
        m_intervals.Add(2, "SecondeMaj");
        m_intervals.Add(3, "TierceMin");
        m_intervals.Add(4, "TierceMaj");
        m_intervals.Add(5, "Quarte Juste");
        m_intervals.Add(6, "Triton");
        m_intervals.Add(7, "Quinte Juste");
        m_intervals.Add(8, "SixteMin");
        m_intervals.Add(9, "SixteMaj");
        m_intervals.Add(10, "SeptiemeMin");
        m_intervals.Add(11, "SeptiemeMaj");
        m_intervals.Add(12, "Octave");
    }

    public void initNotes()
    {  
        string path = "Sound/Piano/mp3_Notes/";
        m_playableNotes.Add(0, new MusicNote("Do_0", Resources.Load<AudioClip>(path+"c3")));
        m_playableNotes.Add(1, new MusicNote("Do#_1", Resources.Load<AudioClip>(path+"c-3")));
        m_playableNotes.Add(2, new MusicNote("Re_2", Resources.Load<AudioClip>(path+"d3")));
        m_playableNotes.Add(3, new MusicNote("Re#_3", Resources.Load<AudioClip>(path+"d-3")));
        m_playableNotes.Add(4, new MusicNote("E_4", Resources.Load<AudioClip>(path+"e3")));
        m_playableNotes.Add(5, new MusicNote("Fa_5", Resources.Load<AudioClip>(path+"f3")));
        m_playableNotes.Add(6, new MusicNote("Fa#_6", Resources.Load<AudioClip>(path+"f-3")));
        m_playableNotes.Add(7, new MusicNote("Sol_7", Resources.Load<AudioClip>(path+"g3")));
        m_playableNotes.Add(8, new MusicNote("Sol#_8", Resources.Load<AudioClip>(path+"g-3")));
        m_playableNotes.Add(9, new MusicNote("La_9", Resources.Load<AudioClip>(path+"a4")));
        m_playableNotes.Add(10, new MusicNote("La#_10", Resources.Load<AudioClip>(path+"a-4")));
        m_playableNotes.Add(11, new MusicNote("Si_11", Resources.Load<AudioClip>(path+"b4")));
        m_playableNotes.Add(12, new MusicNote("Do_12", Resources.Load<AudioClip>(path+"c4")));
    }

    public void playNote(AudioClip noteclip)
    {
        m_MyAudioSource.PlayOneShot(noteclip);   
    }

    public void genInterval()
    {         
        //On get les deux notes de l'intervale
        int first_note = Random.Range(0, 12);
        int second_note = 0;

        do
        {
            second_note = Random.Range(0, 12);
        }
        while(second_note == first_note);

        int intervalle = Mathf.Abs(second_note - first_note);

        StartCoroutine(playInterval(first_note, second_note));

        string reponse = "First Note : " + first_note + " Seconde Note : " + second_note + " Interval : " + m_intervals[intervalle];
        Debug.Log(reponse);
        text_reponse.text = reponse;

    }

    public IEnumerator playInterval(int first_note, int second_note)
    {
        playNote(m_playableNotes[first_note].m_clip);
        yield return new WaitUntil(() => m_MyAudioSource.isPlaying == false);
        playNote(m_playableNotes[second_note].m_clip);     
    }
}
