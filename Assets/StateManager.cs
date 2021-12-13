using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StateManager : MonoBehaviour
{

    public enum State
    {
        Stop,
        Play,
        Pause
    }

    private int elel = 0, lateNum = 6;
    private float[] lates;
    private State state = State.Stop;
    private ButtonManager bm;
    private MasuManager mm;

    // Use this for initialization
    void Start()
    {
        lates = new[]
        {
            0.01f,
            0.02f,
            0.05f,
            0.1f,
            0.2f,
            0.5f,
            1f,
            2f,
            5f
        };

        bm = GetComponent<ButtonManager>();

        bm.SetLate(Late);

        mm = GetComponent<MasuManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void StopState()
    {
        elel = 0;

        SetElel();

        mm.ReSetMasu();
    }

    void SetButtonText()
    {
        bm.SetButtonText(state == State.Play);
    }

    void SetLate()
    {
        lateNum = Mathf.Clamp(lateNum, 0, lates.Length - 1);

        bm.SetLate(Late);
    }

    void SetElel()
    {
        bm.SetElel(elel);
    }

    public void ButtonStartPause()
    {

        if (state == State.Play)
        {
            state = State.Pause;

            bm.NoInteractable();
        }
        else
        {
            state = State.Play;

            StartCoroutine(Play());

            bm.SetStopInteractable(true);

            mm.SetMasuInteractable(false);
        }

        SetButtonText();
    }

    public void ButtonStop()
    {
        if (state == State.Play)
            bm.NoInteractable();
        else if (state == State.Pause)
            StopState();

        state = State.Stop;

        SetButtonText();
    }

    public void ButtonLateUP()
    {
        lateNum++;

        SetLate();
    }

    public void ButtonLateDN()
    {
        lateNum--;

        SetLate();
    }

    IEnumerator Play()
    {
        while (state == State.Play)
        {
            yield return new WaitForSeconds(Late);

            elel++;

            SetElel();

            mm.MasuHantei();
        }

        bm.SetStartPauseInteractable(true);

        mm.SetMasuInteractable(true);

        if (state == State.Pause)
            bm.SetStopInteractable(true);

        if (state == State.Stop)
            StopState();
    }

    float Late
    {
        get
        {
            return lates[lateNum];
        }
    }
}
