﻿/*
Copyright (c) 2011, Sean Kasun
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice, this
  list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections;

namespace Terrafirma
{
    /// <summary>
    /// Interaction logic for HilightWin.xaml
    /// </summary>
    public partial class HilightWin : Window
    {
        class HTile : IComparable
        {
            private string name;
            private int num;
            public HTile(string name, int num)
            {
                this.name = name;
                this.num = num;
            }
            public int Num
            {
                get { return num; }
            }
            public override string ToString()
            {
                return name;
            }
            int IComparable.CompareTo(object obj)
            {
                HTile h = (HTile)obj;
                int r = String.Compare(this.name, h.name);
                if (r == 0)
                {
                    if (this.num < h.num) r = -1;
                    else if (this.num > h.num) r = 1;
                }
                return r;
            }
        }
        ArrayList theTiles;
        public HilightWin(ArrayList tiles)
        {
            InitializeComponent();

            theTiles = new ArrayList();
            int i=0;
            foreach (string name in tiles)
            {
                theTiles.Add(new HTile(name,i++));
            }
            theTiles.Sort();
            tileList.ItemsSource = theTiles;
        }
        public int SelectedItem {
            get {
                return (tileList.SelectedItem as HTile).Num;
            }
        }


        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        private void hilight_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void tileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hilightbutton.IsEnabled = true;
        }
    }
}