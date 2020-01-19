using System.Collections.Generic;

using EscapeRecruitmentRoom.Core.Logic.Board;
using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Core.Model;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        public GameManager Manager { get; }

        public IReadOnlyCollection<IReadOnlyCollection<Tile>> Tiles { get; set; }

        public RelayCommand Left { get; }
        public RelayCommand Right { get; }
        public RelayCommand Up { get; }
        public RelayCommand Down { get; }
        public RelayCommand Restart { get; }

        public RoomViewModel()
        {
            // todo: resolve
            Manager = new GameManager(new BoardProvider());
            Manager.StartGame();

            Tiles = Manager.GameState.Tiles;

            Left = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Left));

            Right = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Right));

            Up = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Up));

            Down = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Down));
        }

        private void RestartImpl()
        {
            Manager.Restart();
            Tiles = Manager.GameState.Tiles;
            this.RaisePropertyChanged(nameof(Tiles));
        }
    }
}
