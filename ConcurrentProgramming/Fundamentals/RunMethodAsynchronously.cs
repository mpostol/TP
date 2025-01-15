//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2025, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.Fundamentals
{
  /// <summary>
  /// Class that allows running method asynchronously
  /// </summary>
  /// <remarks>The RunMethodAsynchronously class is designed to run methods asynchronously using delegates.</remarks>
  public class RunMethodAsynchronously
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RunMethodAsynchronously"/> class.
    /// </summary>
    /// <remarks>
    /// The constructor takes a delegate of type <seealso cref="AsyncOperation"/> and 
    /// assigns it to a private readonly field AsyncOperationField.
    /// </remarks>
    /// <param name="operationToRun">Delegate to method that will be called asynchronously</param>
    public RunMethodAsynchronously(AsyncOperation operationToRun)
    {
      AsyncOperationField = operationToRun;
    }

    /// <summary>
    /// Delegate for method that will be called asynchronously
    /// </summary>
    /// <remarks>
    /// AsyncOperation is a delegate that represents a method that takes an array of objects as parameters and returns void.
    /// </remarks>
    public delegate void AsyncOperation(object[] parameters);

    /// <summary>
    /// Runs the method asynchronously. Return immediately.
    /// </summary>
    /// <remarks>This method starts the asynchronous operation. It creates an AsyncCallback delegate pointing to the 
    /// MyAsyncCallback method and calls BeginInvoke on the AsyncOperationField delegate, passing the parameters and callback.
    /// <param name="parameters">parameters for the method to be executed</param>
    public void RunAsync(object[] parameters)
    {
      AsyncCallback callBack = new AsyncCallback(MyAsyncCallback);
      //TODO: This method is not supported on this platform
      AsyncOperationField.BeginInvoke(parameters, callBack, null);
    }

    /// <summary>
    /// Runs the asynchronously method without any additional parameters
    /// </summary>
    public void RunAsync()
    {
      RunAsync(null);
    }

    #region private

    private readonly AsyncOperation AsyncOperationField;

    /// <summary>
    /// This method is called after asynchronous call
    /// </summary>
    /// <remarks>This private method is called when the asynchronous operation completes. It calls EndInvoke on the AsyncOperationField 
    /// delegate to complete the asynchronous call and retrieve any results.</remarks>
    /// <param name="asyncResult">The result captured as the <see cref="IAsyncResult"/> instance.</param>
    private void MyAsyncCallback(IAsyncResult asyncResult)
    {
      AsyncOperationField.EndInvoke(asyncResult);
    }

    #endregion private
  }
}