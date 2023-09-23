using UnityEngine;
using UnityEngine.UI;
public class DisplayName : MonoBehaviour
{
    Text teks;
    // Start is called before the first frame update
    void Start()
    {
        teks = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        teks.text = PlayerPrefs.GetString("Name");
    }
}
