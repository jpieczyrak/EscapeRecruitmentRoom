using System;
using System.Globalization;
using System.Windows.Data;

using EscapeRecruitmentRoom.Core.Model;

namespace EscapeRecruitmentRoom.Presentation.Converters
{
    public class DirectionToHeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (Direction)value;

            switch (type)
            {
                case Direction.None:
                    return null;
                case Direction.Left:
                    return "pack://application:,,,/Resources/Images/hero_left.png";
                case Direction.Right:
                    return "pack://application:,,,/Resources/Images/hero_right.png";
                case Direction.Up:
                    return "pack://application:,,,/Resources/Images/hero_back.png";
                case Direction.Down:
                    return "pack://application:,,,/Resources/Images/hero_front.png";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}