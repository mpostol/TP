//____________________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//_____________________________________________________________________________________________________________________________________

namespace TP.ConcurrentProgramming.BusinessLogic
{
  internal class BusinessBall : IBall
  {
    public Position position;
    
    public BusinessBall(double yStart, double xStart)
    {
      position = new Position(yStart, xStart);
    }

    public event EventHandler<Position>? NewPositionNotification;

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}