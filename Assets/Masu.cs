using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Masu : MonoBehaviour
{
    private bool isLife = false, isChanged = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetChange()
    {
        isChanged = true;
    }

    public void DeathORBirth()
    {
        if (!isChanged)
            return;

        isLife = !isLife;
        isChanged = false;

        SetColor();
    }

    public void ReSetMasu()
    {
        if (!isLife)
            return;

        isLife = isChanged = false;

        SetColor();
    }

    void SetColor()
    {
        GetComponent<Image>().color = isLife ? Color.black : Color.white;
    }

    public void SetButtonInteractable(bool value)
    {
        GetComponent<Button>().interactable = value;
    }

    public void ReBirth()
    {
        isLife = !isLife;

        SetColor();
    }

    public bool IsLife
    {
        get
        {
            return isLife;
        }
    }
}
