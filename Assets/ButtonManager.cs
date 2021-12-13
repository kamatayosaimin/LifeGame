using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button start_pause, stop, secUp, secDn;
    public Text elel, late;
    private StateManager suwa;

    // Use this for initialization
    void Start()
    {
        suwa = GetComponent<StateManager>();

        SetButtonText(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetStartPauseInteractable(bool value)
    {
        start_pause.interactable = value;
    }

    public void SetStopInteractable(bool value)
    {
        stop.interactable = value;
    }

    public void NoInteractable()
    {
        start_pause.interactable = stop.interactable = false;
    }

    public void SetButtonText(bool isPlaying)
    {
        start_pause.GetComponentInChildren<Text>().text = isPlaying ? "PAUSE" : "START";
    }

    public void SetLate(float l)
    {
        late.text = l.ToString("0.00") + " SEC.";
    }

    public void SetElel(int e)
    {
        elel.text = e.ToString("00000");
    }

    public void ButtonStartPause()
    {
        suwa.ButtonStartPause();
    }

    public void ButtonStop()
    {
        suwa.ButtonStop();
    }

    public void ButtonLateUP()
    {
        suwa.ButtonLateUP();
    }

    public void ButtonLateDN()
    {
        suwa.ButtonLateDN();
    }
}
