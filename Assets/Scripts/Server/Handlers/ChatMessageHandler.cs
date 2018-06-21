using System;
using Client.Models;
using Models;
using Models.RegularGame;
using Models.SuperGame;
using Server.Interfaces;
using Server.Signals;
using UnityEngine.Networking;

namespace Server.Handlers
{
    public class ChatMessageHandler : IServerHandler
    {
        /// <summary>
        /// Message Type
        /// </summary>
        public short MessageType => MsgStruct.EchoMsgId;

        /// <summary>
        /// Send regular room message signal
        /// </summary>
        [Inject]
        public SendRegularRoomMessageSignal SendRegularRoomMessageSignal { get; set; }

        /// <summary>
        /// Send super room message signal
        /// </summary>
        [Inject]
        public SendSuperRoomMessageSignal SendSuperRoomMessageSignal { get; set; }

        /// <summary>
        /// Room list data
        /// </summary>
        [Inject]
        public RoomsListData RoomsListData { get; set; }

        /// <summary>
        /// On Message Handle 
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NetworkMessage message)
        {
            var clientMsg = message.ReadMessage<ClientMessage>();

            switch (clientMsg.RoomType)
            {
                case RoomType.Regular:
                    switch (clientMsg.Status)
                    {
                        case StatusMsg.Adding:
                            foreach (var regularGame in RoomsListData.RegularGames)
                            {
                                SendRegularRoomMessageSignal.Dispatch(new RegularGameMessage
                                {
                                    CurrentPlayers = regularGame.CurrentPlayers,
                                    Id = regularGame.Id,
                                    MaxPlayers = regularGame.MaxPlayers,
                                    Name = regularGame.Name,
                                    Price = regularGame.Price
                                });
                            }

                            break;
                        case StatusMsg.Editing:
                            if (clientMsg.Id != null)
                            {
                                var index = RoomsListData.RegularGames.FindIndex(game => game.Id == clientMsg.Id);
                                if (index > 0)
                                {
                                    // Update curent players
                                    RoomsListData.RegularGames[index].CurrentPlayers = clientMsg.CurrentPlayers;
                                    // Send updated regular game
                                    SendRegularRoomMessageSignal.Dispatch(new RegularGameMessage
                                    {
                                        CurrentPlayers = RoomsListData.RegularGames[index].CurrentPlayers,
                                        Id = RoomsListData.RegularGames[index].Id,
                                        MaxPlayers = RoomsListData.RegularGames[index].MaxPlayers,
                                        Name = RoomsListData.RegularGames[index].Name,
                                        Price = RoomsListData.RegularGames[index].Price
                                    });
                                }
                            }

                            break;
                        case StatusMsg.Sending:
                            break;
                        case StatusMsg.Deleting:
                            break;
                        case StatusMsg.Printing:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                case RoomType.Super:
                    if (clientMsg.Status == StatusMsg.Adding)
                    {
                        foreach (var superGame in RoomsListData.SuperGames)
                        {
                            SendSuperRoomMessageSignal.Dispatch(new SuperGameMessage
                            {
                                CurrentPlayers = superGame.CurrentPlayers,
                                Id = superGame.Id,
                                MaxPlayers = superGame.MaxPlayers,
                                Price = superGame.Price
                            });
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}