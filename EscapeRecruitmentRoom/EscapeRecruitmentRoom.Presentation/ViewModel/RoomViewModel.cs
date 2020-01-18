using System.Collections.Generic;

using EscapeRecruitmentRoom.Core.Logic.Board;
using EscapeRecruitmentRoom.Core.Model;

using GalaSoft.MvvmLight;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        private BoardManager _manager;

        public IReadOnlyCollection<IReadOnlyCollection<Tile>> Tiles { get; set; }

        public RoomViewModel()
        {
            var provider = new BoardProvider();
            _manager = new BoardManager(provider);

            Tiles = _manager.Tiles;
        }
    }
}
