﻿using CozyArce.Tree.Shared;
using CozyArce.Tree.Shared.Model;
using System;

namespace CozyArce.Tree.Generators
{
    public class LowGenerator : ITreeGenerator
    {
        const double PI = 3.1415926;
        Random rand = new Random();
        CozyTree tree;

        public CozyTree Generate()
        {
            tree = new CozyTree();
            DrawTree(500f, 850f, PI / 2, 200, 30);
            return tree;
        }
        public void DrawTree(float X, float Y, double angle, double length, short width)
        {
            if (length < 5)
            {
                if (length < 4.98)
                {
                    tree.Leaves.Add(new CozyLeaf()
                    {
                        beginX = X,
                        beginY = Y,
                        endX = X + 2 * (float)Math.Cos(angle),
                        endY = Y+ 2 * (float)Math.Cos(angle),
                    });
                    return;
                }
                else
                {
                    tree.Flowers.Add(new CozyFlower()
                    {
                        posX = X,
                        posY = Y,
                        size = 3,
                    });
                }
                return;
            }

            float x = X + (float)(length * Math.Cos(angle));
            float y = Y - (float)(length * Math.Sin(angle));

            tree.Branchs.Add(new CozyBranch()
            {
                beginX = X,
                beginY = Y,
                endX = x,
                endY = y,
                width = width,
            });

            width -= (short)rand.Next(5, 8);
            if (width < 1) width = 1;
            var sub = rand.Next(2, 4);
            for (var i = 0; i < sub; ++i)
            {
                var len = rand.NextDouble();
                if (len < 0.4) len += 0.4;
                if (len > 0.8) len -= 0.2;
                DrawTree(x, y, angle + (rand.NextDouble() - 0.5) * PI / 2, len * length, width);
            }
        }
    }
}
