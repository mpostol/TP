//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2023, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_____________________________________________________________________________________________________________________________________

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TP.GraphicalData.Model;
using TP.GraphicalData.ViewModel.MVVMLight;

namespace TP.GraphicalData.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    #region constructors

    /// <summary>
    /// The constructor used by the View sublayer to create the DataContext
    /// </summary>
    public MainViewModel() : this(null) { }

    /// <summary>
    /// The constructor used by the unit tests
    /// </summary>
    /// <param name="dataLayer"></param>
    public MainViewModel(ModelSublayerAPI dataLayer)
    {
      ShowTreeViewMainWindowCommend = new RelayCommand(ShowTreeViewMainWindow);
      FetchDataCommend = new RelayCommand(() => DataLayer = dataLayer ?? ModelSublayerAPI.Create());
      DisplayTextCommand = new RelayCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(m_ActionText));
      m_ActionText = "Text to be displayed on the pop-up";
    }

    #endregion constructors

    #region ViewModel API

    /// <summary>
    /// A list of users exposed on the screen
    /// </summary>
    public ObservableCollection<IUser> Users
    {
      get => m_Users;
      set
      {
        m_Users = value;
        RaisePropertyChanged();
      }
    }

    /// <summary>
    /// A selected user
    /// </summary>
    public IUser CurrentUser
    {
      get => m_CurrentUser;
      set
      {
        m_CurrentUser = value;
        RaisePropertyChanged();
      }
    }

    /// <summary>
    /// A text entered on the screen using the appropriate text box that is to be displayed by an independent message box
    /// </summary>
    public string ActionText
    {
      get => m_ActionText;
      set
      {
        m_ActionText = value;
        DisplayTextCommand.RaiseCanExecuteChanged();
        RaisePropertyChanged();
      }
    }

    /// <summary>
    /// An implementation of the <seealso cref="ICommand"/> bonded with a button to open a message box displaying entered text in the associated text box
    /// </summary>
    public RelayCommand DisplayTextCommand
    {
      get; private set;
    }

    /// <summary>
    /// An implementation of the <seealso cref="ICommand"/> bonded with a button to simulate data fetching from the layer beneath.
    /// </summary>
    public ICommand FetchDataCommend
    {
      get; private set;
    }

    /// <summary>
    /// An implementation of the <seealso cref="ICommand"/> bonded with a button to show a new window contaminating a tree view control
    /// </summary>
    public ICommand ShowTreeViewMainWindowCommend
    {
      get; private set;
    }

    /// <summary>
    /// A callback that provides functionality to create a new child window by the layer above avoiding referencing to the types defined by the layer above.
    /// </summary>
    public Func<IWindow> ChildWindow { get; set; }

    /// <summary>
    /// A callback that provides functionality to show a message displacing a text entered in the associated text box.
    /// </summary>
    public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the View sublayer");

    #endregion ViewModel API

    #region Private stuff

    private ModelSublayerAPI DataLayer
    {
      get => m_DataLayer;
      set
      {
        m_DataLayer = value;
        Users = new ObservableCollection<IUser>(value.User);
      }
    }

    private ModelSublayerAPI m_DataLayer;
    private IUser m_CurrentUser;
    private string m_ActionText;
    private ObservableCollection<IUser> m_Users;

    private void ShowPopupWindow()
    {
      MessageBoxShowDelegate(ActionText);
    }

    private void ShowTreeViewMainWindow()
    {
      IWindow child = ChildWindow();
      child.Show();
    }

    #endregion Private stuff
  }
}