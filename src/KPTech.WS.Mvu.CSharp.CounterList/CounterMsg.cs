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
    public sealed class CounterMsg: Msg
    {
        private readonly int _index;
        private readonly Counter.Msg _msg;
        
        public CounterMsg(int index, Counter.Msg msg) : base(1)
        {
            _index = index;
            _msg = msg;
        }

        public int Index => _index;
        public Counter.Msg Msg => _msg;
    }
}