using Assets.Load;
using Assets.Scripts;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool gameEnded = false;
    public Player[] players;
    public GameObject player;
    public Hexmap hexmap;
    private int _activePlayerId;
    public InterfacePanel interfacePanel;
    public HexColorAi hexColorAi;
    public bool endTurn;
    public int turn = 0;

    private void Awake()
    {
        players = new Player[PlayerSettings.activePlayers];
        for (int i = 0; i < PlayerSettings.activePlayers; i++)
        {
            GameObject p = Instantiate(player, transform);
            players[i] = p.GetComponent<Player>();
            players[i].id = i;
            players[i].playerName = PlayerSettings.names[i];
            players[i].startingHex = hexmap.startingHexagons[i];
            hexmap.startingHexagons[i].SetPlayer(players[i]);
        }
        var ais = PlayerSettings.activeAis;
        var playerCnt = players.Length;
        while (ais > 0)
        {
            players[playerCnt - 1].ai = true;
            ais--;
            playerCnt--;
        }
        hexmap.Init();
    }
    void Start()
    {
        if (LoadProperties.GameLoading)
        {
            Load();
        }
        else
        {
            GameStart();
        } 
    }

    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (endTurn)
        {
            Turn(GetPlayer());
        }
    }

    public string GetPlayerName()
    {
        return players[_activePlayerId].playerName;
    }

    public Player GetPlayer()
    {
        return players[_activePlayerId];
    }
    public void NextPlayer()
    {
        CheckVictory();
        if (_activePlayerId + 1 == players.Length)
        {
            _activePlayerId = 0;
        }
        else
        {
            _activePlayerId++;
        }

        hexmap.ResetAll();

        endTurn = true;
    }

    public void Turn(Player player)
    {
        turn++;
        Debug.Log("turn: " + turn);
        endTurn = false;
        if (GetPlayer().ai)
        {
            hexColorAi.AiTurn(GetPlayer());
        }
        else
        {
            interfacePanel.NewTurn(player);
        }
    }

    public void GameEnd()
    {
        var winner = players[players.Length-1];
        foreach (var player in players)
        {
            if (player.GetHexes() > winner.GetHexes())
            {
                winner = player;
            }
        }
        interfacePanel.GameEnded(winner);
        gameEnded = true;
    }

    public void GameStart()
    {
        _activePlayerId = 0;
        endTurn = true;
    }

    public void CheckVictory()
    {
        foreach (var hex in hexmap.hexagons)
        {
            if (hex.GetPlayer() == null)
            {
                return;
            }
        }
        GameEnd();
    }

    public void Load()
    {
        var hexagonModels = LoadProperties.HexagonModels;

        var indexer = 0;
        foreach(var hexagon in hexmap.hexagons)
        {
            var model = hexagonModels.ElementAt(indexer);
            hexagon._player = model.Player;

            for (int i = 0; i < interfacePanel.ColorButtons.materials.Length; i++)
            {
                if (model.Color == interfacePanel.ColorButtons.materials[i].color)
                {
                    hexagon.GetComponent<MeshRenderer>().material = interfacePanel.ColorButtons.materials[i];
                }
            }

            indexer++;
        }
        LoadProperties.GameLoading = false;
    }
}
