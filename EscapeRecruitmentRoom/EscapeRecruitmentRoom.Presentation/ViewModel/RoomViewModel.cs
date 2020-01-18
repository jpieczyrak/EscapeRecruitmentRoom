using System.Collections.Generic;

using EscapeRecruitmentRoom.Core.Logic.Board;
using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Core.Model;

using GalaSoft.MvvmLight;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        public GameManager Manager { get; }

        public IReadOnlyCollection<IReadOnlyCollection<Tile>> Tiles { get; set; }

        public RoomViewModel()
        {
            // todo: resolve
            Manager = new GameManager(new BoardProvider());
            Manager.StartGame();

            Tiles = Manager.BoardManager.Tiles;
        }
    }
}
