using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public TMP_InputField chatBox;
    [SerializeField]
    List<Message> messageList = new List<Message>();
    public Color playerMessage, npcMessage, info;

    void Update()
    {
        if(chatBox.text != ""){
            if(Input.GetKeyDown(KeyCode.Return)){
                SendMessageToChat("You: " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else{
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Tab)){
                chatBox.Select();
                chatBox.ActivateInputField();
            }

        }
        if(!chatBox.isFocused){
            if(Input.GetKeyDown(KeyCode.Space)){
                SendMessageToChat("hello", Message.MessageType.info);
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.Tab)){
                chatBox.DeactivateInputField();
            }
        }
    }
    Color MessageTypeColor(Message.MessageType messageType){
        Color color = info;
        switch(messageType){
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
            case Message.MessageType.npcMessage:
                color = npcMessage;
                break;
        }
        return color;
    }
    public void SendMessageToChat(string text, Message.MessageType messageType){
        if(messageList.Count >= maxMessages){
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();
        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        if(newMessage.textObject != null){
            newMessage.textObject.text = newMessage.text;
            newMessage.textObject.color = MessageTypeColor(messageType);
        }
        else{
            UnityEngine.Debug.LogError("bleh");
        }
        messageList.Add(newMessage);
    }
}
[System.Serializable]
public class Message{
    public string text;
    public Text textObject;
    public MessageType messageType;
    public enum MessageType{
        playerMessage,
        npcMessage,
        info
    }
}
