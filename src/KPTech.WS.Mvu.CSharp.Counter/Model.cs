// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using WebSharper;

namespace KPTech.WS.Mvu.CSharp.Counter
{
	[JavaScript]
	public struct Model
	{
		private readonly int _id;
	    private readonly int _counter;
	    public Model(int id, int counter)
	    {
		    _id = id;
		    _counter = counter;
	    }

	    public int Id => _id;
	    public int Counter => _counter;	    
    }
}
