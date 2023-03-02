﻿using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BugFablesSaveEditor;

public class EnumValueConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter,
    CultureInfo culture)
  {
    int intValue = 0;
    if (parameter is Type)
    {
      intValue = (int)Enum.Parse((Type)parameter, value.ToString());
    }

    return intValue;
  }

  public object ConvertBack(object value, Type targetType, object parameter,
    CultureInfo culture)
  {
    Enum enumValue = default;
    if (parameter is Type)
    {
      enumValue = (Enum)Enum.Parse((Type)parameter, value.ToString());
    }

    return enumValue;
  }
}
