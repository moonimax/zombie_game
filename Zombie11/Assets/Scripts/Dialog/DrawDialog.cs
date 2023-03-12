using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class DrawDialog : MonoBehaviour
{
    public string xmlFile = "Dialog";

    private XmlNodeList allNodes;
    private Queue<Dialog> dialogs;

    public Text nameText;
    public Text sentenceText;

    public GameObject npcImage;
    public GameObject nextButton;

    private int nextDialog;

    private void Start()
    {
        LoadDialogXml(xmlFile);

        dialogs = new Queue<Dialog>();
        InitDialog();
    }

    private void InitDialog()
    {
        dialogs.Clear();

        npcImage.SetActive(false);
        nameText.text = "";
        sentenceText.text = "";

        nextButton.SetActive(false);
    }

    private void LoadDialogXml(string filename)
    {
        TextAsset xmlFile = Resources.Load<TextAsset>("Dialog/" + filename);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlFile.text);
        allNodes = xmlDoc.SelectNodes("root/Dialog");
    }

    public void StartDialog(int dialogIndex)
    {
        foreach (XmlNode node in allNodes)
        {
            int num = int.Parse(node["number"].InnerText);
            if(num == dialogIndex)
            {
                Dialog dialog = new Dialog();
                dialog.number = num;
                dialog.charater = int.Parse(node["character"].InnerText);
                dialog.name = node["name"].InnerText;
                dialog.sentence = node["sentence"].InnerText;
                dialog.next = int.Parse(node["next"].InnerText);

                dialogs.Enqueue(dialog);
            }
        }

        //첫번째 대화를 보여준다
        DrawNext();
    }

    public void DrawNext()
    {
        if(dialogs.Count == 0)
        {
            EndDialog();
            return;
        }

        nextButton.SetActive(false);

        Dialog dialog = dialogs.Dequeue();

        if (dialog.charater > 0)
        {
            npcImage.SetActive(true);
            npcImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Dialog/npc/npc0" + dialog.charater.ToString());
        }
        else //dialog.charater <= 0
        {
            npcImage.SetActive(false);
        }

        nextDialog = dialog.next;

        nameText.text = dialog.name;
        StartCoroutine(typingSentence(dialog.sentence));
    }

    IEnumerator typingSentence(string typingText)
    {
        sentenceText.text = "";

        foreach (char latter in typingText)
        {
            sentenceText.text += latter;
            yield return new WaitForSeconds(0.03f);
        }

        nextButton.SetActive(true);
    }

    private void EndDialog()
    {
        InitDialog();

        //대화 종료시 이벤트, 처리
        //대화창 종료 후 다음 대화가 있는지 체크
        if(nextDialog >= 0)
        {
            StartDialog(nextDialog);
        }
    }

}
