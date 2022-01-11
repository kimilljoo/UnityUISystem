using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NavigationView : MonoBehaviour
{
    [SerializeField]
    private RectTransform currentView;
    [SerializeField]
    private TextMeshProUGUI textTitle;
    [SerializeField]
    private Button buttonPrev;
    [SerializeField]
    private TextMeshProUGUI textPrevName;

    private CanvasGroup canvasGroup;
    private Stack<RectTransform> stackViews;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        stackViews = new Stack<RectTransform>();

        buttonPrev.onClick.AddListener(Pop);
        buttonPrev.gameObject.SetActive(false);

        SetNavigationBar(currentView.name);

    }

    public void Push(RectTransform newView)
    {
        canvasGroup.blocksRaycasts = false;

        RectTransform previousView = currentView;
        previousView.gameObject.SetActive(false);
        stackViews.Push(previousView);

        currentView = newView;
        currentView.gameObject.SetActive(true);

        canvasGroup.blocksRaycasts = true;

        SetNavigationBar(currentView.name, previousView.name);

    }

    public void Pop()
    {
        if(stackViews.Count < 1)
        {
            return;
        }


        canvasGroup.blocksRaycasts = false;

        RectTransform previousView = currentView;
        previousView.gameObject.SetActive(false);

        currentView = stackViews.Pop();
        currentView.gameObject.SetActive(true);

        canvasGroup.blocksRaycasts = true;

        if ( stackViews.Count >= 1)
        {
            SetNavigationBar(currentView.name, stackViews.Peek().name);
        }

        else
        {
            SetNavigationBar(currentView.name);
        }

    }

    public void SetNavigationBar(string title, string prevBtnName = "")
    {
        textTitle.text = title;

        if (prevBtnName.Equals(""))
        {
            buttonPrev.gameObject.SetActive(false);
        }
        else
        {
            buttonPrev.gameObject.SetActive(true);
            textPrevName.text = prevBtnName;
        }
    }


}
