using System;
using System.Globalization;
using System.Windows.Data;

using EscapeRecruitmentRoom.Core.Model;

namespace EscapeRecruitmentRoom.Presentation.Converters
{
    public class ContentTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (ContentType)value;

            switch (type)
            {
                case ContentType.Floor:
                    return "pack://application:,,,/Resources/Images/default_acacia_tree.png";
                case ContentType.Rock:
                    return "pack://application:,,,/Resources/Images/default_brick.png";
                case ContentType.Wood:
                    return "pack://application:,,,/Resources/Images/default_wood.png";
                case ContentType.Lava:
                    return "pack://application:,,,/Resources/Images/default_lava.png";
                case ContentType.Water:
                    return "pack://application:,,,/Resources/Images/default_water.png";
                case ContentType.Gas:
                    return "pack://application:,,,/Resources/Images/default_item_smoke.png";
                case ContentType.Key:
                    return "pack://application:,,,/Resources/Images/default_key_skeleton.png";
                case ContentType.Door:
                    return "pack://application:,,,/Resources/Images/doors_item_steel.png";
                case ContentType.Hero:
                    return "pack://application:,,,/Resources/Images/default_gold_lump.png";
            }

            return "pack://application:,,,/Resources/Images/default_obsidian.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
