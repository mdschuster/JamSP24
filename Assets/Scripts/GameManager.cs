using System;
using System.Collections;
using UnityEngine;
using Application = UnityEngine.Application;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float timeBeforeStart;
    private float time;
    public bool running;
    public TMP_Text startText;
    public TMP_Text placeText;
    public GameObject finishUI;

    private static GameManager _instance;

    public static GameManager instance()
    {
        return _instance;
    }
    
    private void Awake()
    {
        if (_instance == null) _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        time = timeBeforeStart;
        running = false;
        startText.gameObject.SetActive(true);
        finishUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            running = true;
            startText.text = "START";
            StartCoroutine(disappearObjectAfter(startText.gameObject, 2f));
        }

        if (time > 0)
        {
            startText.text = Mathf.Ceil(time).ToString();
            time -= Time.deltaTime;
        }
    }

    public IEnumerator disappearObjectAfter(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }

    public void MenuButtonPress()
    {
        SceneManager.LoadScene("Menu");
    }

    public void showFinishedUI(int place)
    {
        finishUI.SetActive(true);
        if (place == 1) placeText.text = "First";
        if (place == 2) placeText.text = "Second";
        if (place == 3) placeText.text = "Third";
        if (place == 4) placeText.text = "Fourth";

    }
}
