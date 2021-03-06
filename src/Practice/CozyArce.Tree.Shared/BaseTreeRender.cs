﻿using CozyArce.Tree.Shared.Model;

namespace CozyArce.Tree.Shared
{
    public class BaseTreeRender : ITreeRender
    {
        public ITreeBranchRender    BranchRender;
        public ITreeLeafRender      LeafRender;
        public ITreeFlowerRender    FlowerRender;
        public void Draw(CozyTree tree)
        {
            foreach (var i in tree.Branchs)
                BranchRender?.Draw(i);
            foreach (var i in tree.Leaves)
                LeafRender?.Draw(i);
            foreach (var i in tree.Flowers)
                FlowerRender?.Draw(i);
        }
    }
}
