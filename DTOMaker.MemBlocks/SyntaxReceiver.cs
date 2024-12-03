﻿using DTOMaker.Gentime;
using Microsoft.CodeAnalysis;
using System.Collections.Concurrent;

namespace DTOMaker.MemBlocks
{
    internal class SyntaxReceiver : ISyntaxContextReceiver
    {
        public ConcurrentDictionary<string, TargetDomain> Domains { get; } = new ConcurrentDictionary<string, TargetDomain>();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            SyntaxReceiverHelper.ProcessNode(context, Domains,
                (n, l) => new MemBlockDomain(n, l),
                (d, n, l) => new MemBlockEntity(d, n, l),
                (e, n, l) => new MemBlockMember(e, n, l));
        }
    }
}
