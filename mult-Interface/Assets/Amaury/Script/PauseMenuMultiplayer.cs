using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenuMultiplayer : MonoBehaviour
{

	private NetworkManager networkManager;
	
	// Use this for initialization
	void Start () 
	{
		networkManager = NetworkManager.singleton;
	}

	public void LeaveRoom()
	{
		MatchInfo matchInfo = networkManager.matchInfo;
		networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
		networkManager.StopHost();
	}
}
