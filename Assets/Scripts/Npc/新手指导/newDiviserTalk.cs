using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class newDiviserTalk : MonoBehaviour, InteractEvents
{
    public TalkManager talkWindow;
    public GameObject loadUI;
    public string[] TalkTexts;
    public string[] FightTexts;
    public float time = 1;

    void Start()
    {
        talkWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InteractSystem/TalkWindow")
            .gameObject.GetComponent<TalkManager>();
        loadUI = GameObject.FindGameObjectWithTag("Canvas").transform.Find("LoadingWindow").gameObject;
    }

    public void Talk()
    {
        talkWindow.Show(TalkTexts, TalkNext);
    }

    public void Fight()
    {
        talkWindow.Show(FightTexts, FightNext);
    }

    void FightNext()
    {

    }

    void TalkNext()
    {
        StartCoroutine(loadScene(0));
    }

    public void Exchange()
    {
        TradeManager.Instance.ShowTradeWindow();
    }

    IEnumerator loadScene(int n)
    {
        AsyncOperation asy = SceneManager.LoadSceneAsync(n);
        asy.allowSceneActivation = false;
        loadUI.SetActive(true);
        var slider = loadUI.GetComponentInChildren<Slider>();
        while (time > 0)
        {
            slider.value = asy.progress / 0.9f;
            time -= Time.deltaTime;
            yield return null;
        }
        asy.allowSceneActivation = true;
        loadUI.SetActive(false);

    }

}
