using System;
using System.Collections.Generic;

using EscapeRecruitmentRoom.Core.Logic.Account;
using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Core.Model;
using EscapeRecruitmentRoom.Presentation.Logic;
using EscapeRecruitmentRoom.Presentation.View;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Views;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class RoomViewModel : ViewModelBase, INavigatedTo
    {
        private readonly ILoginService _loginService;
        private readonly IViewNavigator _navigator;
        public IGameManager Manager { get; }

        public IReadOnlyCollection<IReadOnlyCollection<Tile>> Tiles { get; set; }

        private string _commandText;
        private string _message = "Welcome ";

        public string CommandText
        {
            get => _commandText;
            set => Set(ref _commandText, value);
        }

        public string Title => Manager.Title;

        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        public RelayCommand Left { get; }
        public RelayCommand Right { get; }
        public RelayCommand Up { get; }
        public RelayCommand Down { get; }
        public RelayCommand Restart { get; }
        public RelayCommand Logout { get; }
        public RelayCommand Parse { get; }

        public RoomViewModel(IGameManager manager, ILoginService loginService, IViewNavigator navigator)
        {
            _loginService = loginService;
            _navigator = navigator;
            Manager = manager;
            manager.StartGame();

            Tiles = Manager.GameState.Tiles;

            Left = new RelayCommand(() => Go(Direction.Left));
            Right = new RelayCommand(() => Go(Direction.Right));
            Up = new RelayCommand(() => Go(Direction.Up));
            Down = new RelayCommand(() => Go(Direction.Down));

            Parse = new RelayCommand(() =>
            {
                CommandParser.ParseAndRun(CommandText, Manager);
                CommandText = null;
            });

            Logout = new RelayCommand(() => _navigator.NavigateTo(View.Login));
        }

        private void Go(Direction direction)
        {
            try
            {
                Manager.Go(Manager.HeroTile.Code, direction);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
        }

        private void RestartImpl()
        {
            Manager.Restart();
            Tiles = Manager.GameState.Tiles;
            this.RaisePropertyChanged(nameof(Tiles));
        }

        public void Update()
        {
            Message += $"{_loginService.UserName}!";
        }
    }
}
