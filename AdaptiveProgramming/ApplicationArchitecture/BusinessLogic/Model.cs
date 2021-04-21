//____________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/TP
//____________________________________________________________________________

using TPA.ApplicationArchitecture.Data.API;

namespace TPA.ApplicationArchitecture.BusinessLogic
{
  internal class Model
  {
    public ILinq2SQL Linq2SQL { get; set; }

        public Model(IFactory factory)
        {
            Linq2SQL = factory.CreateLinq2SQL();
        }
  }
}
