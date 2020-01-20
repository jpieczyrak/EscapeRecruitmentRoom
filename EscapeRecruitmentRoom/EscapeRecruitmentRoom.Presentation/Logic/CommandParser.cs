using System;

using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Core.Model;

namespace EscapeRecruitmentRoom.Presentation.Logic
{
    public class CommandParser
    {
        public static void ParseAndRun(string content, IGameManager manager)
        {
            if (string.IsNullOrWhiteSpace(content)) return;

            var elements = content.Split(' ');

            if (elements.Length == 2)
            {
                if (string.Equals(elements[0], nameof(GameManager.Go), StringComparison.CurrentCultureIgnoreCase))
                {
                    if (Enum.TryParse(elements[1], true, out Direction direction))
                    {
                        manager.Go(manager.HeroTile.Code, direction);
                    }
                }
                else if (string.Equals(elements[1], nameof(GameManager.FireUp), StringComparison.CurrentCultureIgnoreCase))
                {
                    manager.FireUp(elements[0]);
                }
                else if (string.Equals(elements[1], nameof(GameManager.PutTnt), StringComparison.CurrentCultureIgnoreCase))
                {
                    manager.PutTnt(elements[0]);
                }
            }
            else if (elements.Length == 3)
            {
                if (string.Equals(elements[1], nameof(GameManager.Move), StringComparison.CurrentCultureIgnoreCase))
                {
                    if (Enum.TryParse(elements[2], true, out Direction direction))
                    {
                        string tileCode = elements[0].ToUpper();
                        var movableType = manager.GetMovableType(tileCode);
                        if (movableType != null)
                        {
                            manager.Move(tileCode, direction, movableType.Value);
                        }
                    }
                }
            }
        }
    }
}
