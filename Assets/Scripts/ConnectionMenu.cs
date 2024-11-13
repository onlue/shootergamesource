using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionMenu : MonoBehaviourPunCallbacks
{
    public InputField _connectionAdres;

    public void CreateRoom()
    {
        RoomOptions roomoptions = new RoomOptions();
        roomoptions.MaxPlayers = 4;

        PhotonNetwork.CreateRoom(_connectionAdres.text,roomoptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_connectionAdres.text);
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("currentProggres");
    }
}
