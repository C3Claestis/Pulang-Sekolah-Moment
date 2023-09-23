using UnityEngine;
using UnityEngine.UI;
public class ScrollBar : MonoBehaviour
{
    public GameObject scoolbar;
    float scroolpos = 0;
    float[] pos;
    int position = 0;
    public AudioSource _Suara;
    public AudioClip _Sfx;
    public void next()
    {
        if (position < pos.Length - 1)
        {
            position += 1;
            scroolpos = pos[position];
        }
        _Suara.PlayOneShot(_Sfx);
    }

    public void prev()
    {
        if (position > 0)
        {
            position -= 1;
            scroolpos = pos[position];
        }
        _Suara.PlayOneShot(_Sfx);
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distan = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distan * i;
        }
        if (Input.GetMouseButton(0))
        {
            scroolpos = scoolbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int j = 0; j < pos.Length; j++)
            {
                if (scroolpos < pos[j] + (distan / 2) && scroolpos > pos[j] - (distan / 2))
                {
                    scoolbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scoolbar.GetComponent<Scrollbar>().value, pos[j], 0.15f);
                    position = j;
                }
            }
        }
    }
}
