using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HostGame : MonoBehaviour {

	[SerializeField]
	private uint roomSize = 6;

	private string roomName;

	public InputField roomNameInputField;
	
	private NetworkManager networkManager;

	void Start()
	{
		networkManager = NetworkManager.singleton;
		if (networkManager.matchMaker == null)
		{
			networkManager.StartMatchMaker();
		}
	}

	public void SetRoomName()
	{
		roomName = roomNameInputField.text;
		Debug.Log(roomName);
	}

	public void CreateRoom()
	{
		if (roomName != "" && roomName != null)
		{
			Debug.Log("Creating Room: " + roomName + " with room for " + roomSize + " players.");
			networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate) ;
		}
	}
}
