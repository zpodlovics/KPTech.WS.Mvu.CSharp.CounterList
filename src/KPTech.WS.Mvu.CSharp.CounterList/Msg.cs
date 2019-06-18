// ---------------------------------------------------------------------------
// Copyright (c) 2019, Zoltan Podlovics, KP-Tech Kft. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0. See LICENSE.md in the 
// project root for license information.
// ---------------------------------------------------------------------------

using WebSharper;

namespace KPTech.WS.Mvu.CSharp.CounterList
{
    [JavaScript]
    public class Msg
    {
        private readonly int _tag;

        protected Msg(int tag)
        {
            _tag = tag;
        }
        public int Tag => _tag;
    }
}