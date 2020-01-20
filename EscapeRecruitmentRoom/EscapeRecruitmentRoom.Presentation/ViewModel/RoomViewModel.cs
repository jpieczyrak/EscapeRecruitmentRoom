﻿using System.Collections.Generic;

using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Core.Model;
using EscapeRecruitmentRoom.Presentation.Logic;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        public IGameManager Manager { get; }

        public IReadOnlyCollection<IReadOnlyCollection<Tile>> Tiles { get; set; }

        private string _commandText;

        public string CommandText
        {
            get => _commandText;
            set => Set(ref _commandText, value);
        }

        public RelayCommand Left { get; }
        public RelayCommand Right { get; }
        public RelayCommand Up { get; }
        public RelayCommand Down { get; }
        public RelayCommand Restart { get; }
        public RelayCommand Parse { get; }

        public RoomViewModel(IGameManager manager)
        {
            Manager = manager;
            Manager.StartGame();

            Tiles = Manager.GameState.Tiles;

            Left = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Left));

            Right = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Right));

            Up = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Up));

            Down = new RelayCommand(() => Manager.Go(Manager.HeroTile.Code, Direction.Down));

            Parse = new RelayCommand(() =>
            {
                CommandParser.ParseAndRun(CommandText, Manager);
                CommandText = null;
            });
        }

        private void RestartImpl()
        {
            Manager.Restart();
            Tiles = Manager.GameState.Tiles;
            this.RaisePropertyChanged(nameof(Tiles));
        }
    }
}
