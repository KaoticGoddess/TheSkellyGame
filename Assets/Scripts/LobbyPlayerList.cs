﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LobbyPlayerList : MonoBehaviour {


    private VerticalLayoutGroup _layout;
    public RectTransform PlayerListContentTransform;

    public static LobbyPlayerList Instance = null;

    private readonly List<LobbyPlayer> _players = new List<LobbyPlayer>();

    public void OnEnable() {
        Instance = this;
        _layout = PlayerListContentTransform.GetComponent<VerticalLayoutGroup>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPlayer(LobbyPlayer lobbyPlayer) {

        if (_players.Contains(lobbyPlayer)) return;

        _players.Add(lobbyPlayer);

        lobbyPlayer.transform.SetParent(PlayerListContentTransform, false);

        PlayerListModified();
    }

    public void RemovePlayer(LobbyPlayer player) {
        _players.Remove(player);
        PlayerListModified();
    }
    public void PlayerListModified()
    {
        var i = 0;
        foreach (var lobbyPanelPlayer in _players) {
            lobbyPanelPlayer.OnPlayerListChanged(i++);
        }
    }
}
