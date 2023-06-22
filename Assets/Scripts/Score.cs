using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("rec1") != 0) transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec1").ToString();
        else transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
        if (PlayerPrefs.GetInt("rec2") != 0) transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec2").ToString();
        else transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
        if (PlayerPrefs.GetInt("rec3") != 0) transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec3").ToString();
        else transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
        if (PlayerPrefs.GetInt("rec4") != 0) transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec4").ToString();
        else transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
        if (PlayerPrefs.GetInt("rec5") != 0) transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec5").ToString();
        else transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
        if (PlayerPrefs.GetInt("rec6") != 0) transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("rec6").ToString();
        else transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = "---";
    }
}
