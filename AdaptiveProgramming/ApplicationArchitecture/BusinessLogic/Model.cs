//____________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.BusinessLogic
{
  public class Model
  {
    public ILinq2SQL Linq2SQL { get; set; }

        public Model():this (ILinq2SQL.CreateLinq2SQL())
        {
            
        }
        public Model(ILinq2SQL linq)
        {
            Linq2SQL = linq;
        }
  }
}
