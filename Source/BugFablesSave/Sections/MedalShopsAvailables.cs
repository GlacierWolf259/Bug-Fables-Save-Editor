﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BugFablesSaveEditor.Enums;

namespace BugFablesSaveEditor.BugFablesSave.Sections;

public sealed class
  MedalShopsAvailables : BugFablesDataList<MedalShopsAvailables.MedalsShopAvailableInfo>
{
  public IList<MedalInShopAvailableInfo> Merab { get => List[(int)MedalShop.Merab].List; }
  public IList<MedalInShopAvailableInfo> Shades { get => List[(int)MedalShop.Shades].List; }

  public MedalShopsAvailables()
  {
    ElementSeparator = Utils.SecondarySeparator;
    NbrExpectedElements = (int)MedalShop.COUNT;
    while (List.Count < (int)MedalShop.COUNT)
      List.Add(new MedalsShopAvailableInfo());
  }

  public sealed class MedalsShopAvailableInfo : BugFablesDataList<MedalInShopAvailableInfo>
  {
  }

  public sealed class MedalInShopAvailableInfo : BugFablesData, INotifyPropertyChanged
  {
    private Medal _medal;

    public Medal Medal
    {
      get => _medal;
      set
      {
        if ((int)value == -1)
        {
          return;
        }

        _medal = value;
        NotifyPropertyChanged();
      }
    }

    public override void ResetToDefault()
    {
      Medal = 0;
    }

    public override void Parse(string str)
    {
      Medal = (Medal)ParseField<int>(str, nameof(Medal));
    }

    public override string ToString()
    {
      return ((int)Medal).ToString();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
