using UnityEngine;
using System.Collections;

public class MasuManager : MonoBehaviour
{
    public GameObject masuAsset;
    private Masu[,] masu;

    // Use this for initialization
    void Start()
    {
        masu = new Masu[50, 50];

        float hx = (masu.GetLength(0) - 1f) / 2f, hy = (masu.GetLength(1) - 1f) / 2f;

        for (int y = 0; y < masu.GetLength(1); y++)
            for (int x = 0; x < masu.GetLength(0); x++)
            {
                GameObject m = (GameObject)Instantiate(masuAsset, Vector3.zero, Quaternion.identity);
                RectTransform rt = (RectTransform)m.transform;

                rt.SetParent(transform);

                Vector2 s = rt.sizeDelta, o = Vector2.one * 1f, p = new Vector2(x, -y);

                p.Scale(s + o);

                rt.anchoredPosition = p;

                masu[x, y] = m.GetComponent<Masu>();
            }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MasuHantei()
    {
        for (int y = 0; y < masu.GetLength(1); y++)
            for (int x = 0; x < masu.GetLength(0); x++)
            {
                int life = 0;

                for (int oy = Mathf.Max(0, y - 1); oy < Mathf.Min(y + 2, masu.GetLength(1)); oy++)
                    for (int ox = Mathf.Max(0, x - 1); ox < Mathf.Min(x + 2, masu.GetLength(0)); ox++)
                    {
                        if (masu[ox, oy].IsLife && !(ox == x && oy == y))
                            life++;
                    }

                Masu m = masu[x, y];

                if (m.IsLife)
                {
                    if (life != 2 && life != 3)
                        m.SetChange();
                }
                else if (life == 3)
                    m.SetChange();
            }

        foreach (var m in masu)
            m.DeathORBirth();
    }

    public void ReSetMasu()
    {
        foreach (var m in masu)
            m.ReSetMasu();
    }

    public void SetMasuInteractable(bool value)
    {
        foreach (var m in masu)
            m.SetButtonInteractable(value);
    }
}
