﻿using System.Collections.Generic;
using BugFablesSaveEditor.BugFablesSave;
using BugFablesSaveEditor.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static BugFablesSaveEditor.BugFablesSave.Sections.Medals;
using static BugFablesSaveEditor.BugFablesSave.Sections.MedalShopsAvailables;
using static BugFablesSaveEditor.BugFablesSave.Sections.MedalShopsPools;

namespace BugFablesSaveEditor.ViewModels;

public partial class MedalsViewModel : ObservableObject
{
  [ObservableProperty]
  private ReorderableCollectionViewModel<MedalInfo> _medalsVm = null!;

  [ObservableProperty]
  private ReorderableCollectionViewModel<MedalInShopAvailableInfo> _medalsMerabAvailablesVm = null!;

  [ObservableProperty]
  private ReorderableCollectionViewModel<MedalInShopAvailableInfo>
    _medalsShadesAvailablesVm = null!;

  [ObservableProperty]
  private ReorderableCollectionViewModel<MedalInShopPoolInfo> _medalsMerabPoolsVm = null!;

  [ObservableProperty]
  private ReorderableCollectionViewModel<MedalInShopPoolInfo> _medalsShadesPoolsVm = null!;

  [ObservableProperty]
  private string[] _medalsEquipTargetNames = null!;

  [ObservableProperty]
  private string[] _medalsNames = null!;

  [ObservableProperty]
  private SaveData _saveData = null!;

  [ObservableProperty]
  private Medal _selectedMedalForAdd;

  [ObservableProperty]
  private MedalEquipTarget _selectedMedalEquipTargetForAdd;

  [ObservableProperty]
  private Medal _selectedMedalMerabAvailableForAdd;

  [ObservableProperty]
  private Medal _selectedMedalMerabPoolForAdd;

  [ObservableProperty]
  private Medal _selectedMedalShadesAvailableForAdd;

  [ObservableProperty]
  private Medal _selectedMedalShadesPoolForAdd;

  public MedalsViewModel() : this(new SaveData())
  {
    MedalsVm.Collection.Add(new MedalInfo { Medal = (Medal)7 });
    MedalsVm.Collection.Add(new MedalInfo { Medal = (Medal)51 });
    MedalsVm.Collection.Add(new MedalInfo { Medal = (Medal)78 });

    MedalsMerabPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)62 });
    MedalsMerabPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)51 });
    MedalsMerabPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)78 });

    MedalsShadesPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)35 });
    MedalsShadesPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)52 });
    MedalsShadesPoolsVm.Collection.Add(new MedalInShopPoolInfo { Medal = (Medal)13 });

    MedalsMerabAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)12 });
    MedalsMerabAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)25 });
    MedalsMerabAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)14 });

    MedalsShadesAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)9 });
    MedalsShadesAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)4 });
    MedalsShadesAvailablesVm.Collection.Add(new MedalInShopAvailableInfo { Medal = (Medal)55 });
  }

  public MedalsViewModel(SaveData saveData)
  {
    SaveData = saveData;
    MedalsNames = Utils.GetEnumDescriptions<Medal>();
    MedalsEquipTargetNames = Utils.GetEnumDescriptions<MedalEquipTarget>();
    MedalsVm = new ReorderableCollectionViewModel<MedalInfo>(SaveData.Medals.List);

    MedalsMerabPoolsVm =
      new ReorderableCollectionViewModel<MedalInShopPoolInfo>(SaveData.MedalShopsPools.Merab);
    MedalsMerabAvailablesVm =
      new ReorderableCollectionViewModel<MedalInShopAvailableInfo>(
        SaveData.MedalShopsAvailables.Merab);
    MedalsShadesPoolsVm =
      new ReorderableCollectionViewModel<MedalInShopPoolInfo>(SaveData.MedalShopsPools.Shades);
    MedalsShadesAvailablesVm =
      new ReorderableCollectionViewModel<MedalInShopAvailableInfo>(SaveData.MedalShopsAvailables
        .Shades);
  }

  [RelayCommand]
  private void AddMedal()
  {
    MedalsVm.Collection.Add(new MedalInfo
    {
      Medal = SelectedMedalForAdd, MedalEquipTarget = SelectedMedalEquipTargetForAdd
    });
    MedalsVm.CollectionView.Refresh();
  }

  [RelayCommand]
  private void AddMedalMerabPool()
  {
    MedalsMerabPoolsVm.Collection.Add(new MedalInShopPoolInfo
    {
      Medal = SelectedMedalMerabPoolForAdd
    });
    MedalsMerabPoolsVm.CollectionView.Refresh();
  }

  [RelayCommand]
  private void AddMedalMerabAvailable()
  {
    MedalsMerabAvailablesVm.Collection.Add(
      new MedalInShopAvailableInfo { Medal = SelectedMedalMerabAvailableForAdd });
    MedalsMerabAvailablesVm.CollectionView.Refresh();
  }

  [RelayCommand]
  private void AddMedalShadesPool()
  {
    MedalsShadesPoolsVm.Collection.Add(
      new MedalInShopPoolInfo { Medal = SelectedMedalShadesPoolForAdd });
    MedalsShadesPoolsVm.CollectionView.Refresh();
  }

  [RelayCommand]
  private void AddMedalShadesAvailable()
  {
    MedalsShadesAvailablesVm.Collection.Add(
      new MedalInShopAvailableInfo { Medal = SelectedMedalShadesAvailableForAdd });
    MedalsShadesAvailablesVm.CollectionView.Refresh();
  }

  [RelayCommand]
  private void UnequipAllMedals()
  {
    foreach (MedalInfo medal in MedalsVm.Collection)
      medal.MedalEquipTarget = MedalEquipTarget.Unequipped;
    MedalsVm.CollectionView.Refresh();
  }
}
