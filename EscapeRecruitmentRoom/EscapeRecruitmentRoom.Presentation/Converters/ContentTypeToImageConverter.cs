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
                case ContentType.ObsidianFloor:
                    return "pack://application:,,,/Resources/Images/default_obsidian_block.png";
                case ContentType.ClayFloor:
                    return "pack://application:,,,/Resources/Images/default_dirt.png";
                case ContentType.WoodFloor:
                    return "pack://application:,,,/Resources/Images/doors_trapdoor_side.png";
                case ContentType.Rock:
                    return "pack://application:,,,/Resources/Images/default_brick.png";
                case ContentType.Brick:
                    return "pack://application:,,,/Resources/Images/default_clay_brick.png";
                case ContentType.Wood:
                    return "pack://application:,,,/Resources/Images/wood.png";
                case ContentType.Lava:
                    return "pack://application:,,,/Resources/Images/default_lava.png";
                case ContentType.Water:
                    return "pack://application:,,,/Resources/Images/default_water.png";
                case ContentType.Gas:
                    return "pack://application:,,,/Resources/Images/default_item_smoke_green.png";
                case ContentType.Key:
                    return "pack://application:,,,/Resources/Images/default_key_skeleton.png";
                case ContentType.Door:
                    return "pack://application:,,,/Resources/Images/doors_item_steel.png";
                case ContentType.Torch:
                    return "pack://application:,,,/Resources/Images/default_torch_on_floor.png";
                case ContentType.Tnt:
                    return "pack://application:,,,/Resources/Images/tnt_side.png";
                case ContentType.Fire:
                    return "pack://application:,,,/Resources/Images/fire_basic_flame.png";
                case ContentType.Skull:
                    return "pack://application:,,,/Resources/Images/bones_front.png";
                case ContentType.Hero:
                    return Binding.DoNothing;
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
