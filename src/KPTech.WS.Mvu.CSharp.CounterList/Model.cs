// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using WebSharper;

namespace KPTech.WS.Mvu.CSharp.CounterList
{
	[JavaScript]
	public class Model
	{
		private List<Counter.Model> _counters;
	    public Model(IReadOnlyList<Counter.Model> counters) {
		    _counters = counters.ToList();
	    }

	    public IReadOnlyList<Counter.Model> Counters => _counters;
	    public IEnumerable<Counter.Model> CountersEnumerable => _counters;
	}
}
