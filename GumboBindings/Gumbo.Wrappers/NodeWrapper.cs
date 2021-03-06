﻿using Gumbo.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumbo.Wrappers
{
    public abstract class NodeWrapper
    {
        public GumboNodeType Type { get; private set; }

        /// size_t->unsigned int
        public int Index { get; private set; }

        /// GumboParseFlags->Anonymous_a2031eb3_cd7b_4b09_98eb_e950ead0223f
        public GumboParseFlags ParseFlags { get; private set; }

        public NodeWrapper Parent { get; private set; }

        protected GumboWrapper DisposableOwner;

        public NodeWrapper(GumboWrapper disposableOwner, GumboNode node, NodeWrapper parent)
	    {
            DisposableOwner = disposableOwner;
            Type = node.type;
            Index = (int)node.index_within_parent;
            ParseFlags = node.parse_flags;
            Parent = parent;
	    }

        protected void ThrowIfOwnerDisposed()
        {
            if (DisposableOwner.Disposed)
            {
                throw new ObjectDisposedException("GumboWrapper has already been disposed");
            }
        }
    }
}
