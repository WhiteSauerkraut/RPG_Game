using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * 创建日期：5/02
 * 创建人：lyj
 * 描述：控制Canvas加载到下一场景（若为战斗场景，则隐藏）
 **/
public class CanvasDontDestroy : MonoBehaviour
{
    bool isSetFlag = false;

    GameObject player;

    PlayerAttribute playerAttribute;

    /**
     * 加载到下一场景
     */
    public void Awake()
    {
        if (GameObject.FindGameObjectsWithTag(transform.tag).Length > 1)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(transform.tag);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerAttribute = player.GetComponent<PlayerAttribute>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("battleScene"))
        {
            if (GameObject.FindGameObjectsWithTag("BattleCanvas").Length >= 1 && !isSetFlag)
            {
                isSetFlag = true;
                Hide(this.gameObject);
                GameObject gameObject = new GameObject("RootCanvas");
                this.transform.parent = gameObject.transform;
            }
        }
        else if(!SceneManager.GetActiveScene().name.Equals("battleScene") && isSetFlag)
        {
            Show(gameObject);
            isSetFlag = false;
        }
    }

    public void Show(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    public void Hide(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }

}
