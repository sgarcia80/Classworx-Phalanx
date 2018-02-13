using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;


namespace PhalanxAdmin
{
    class cwxSorter : System.Collections.IComparer
    {
        public cwxSorter()
        {
        }

        public cwxSorter(int column, SortOrder order)
        {
            this.Column = column;
            this.Order = order;
        }

        public int Column = 0;
        public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y) // IComparer Member   
        {
            if (!(x is ListViewItem)) return (0);
            if (!(y is ListViewItem)) return (0);
            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;
            if (l1.ListView.Columns[Column].Tag == null)
            {
                l1.ListView.Columns[Column].Tag = "Text";
            }

            if (l1.ListView.Columns[Column].Tag.ToString().StartsWith("Numeric"))
            {
                float defaultvalue = 0;

                string type = l1.ListView.Columns[Column].Tag.ToString().Replace("Numeric", string.Empty);

                if (!string.IsNullOrEmpty(type))
                {
                    defaultvalue = float.Parse(type);
                }

                float fl1 = 0;
                float fl2 = 0;

                try
                {
                    if (l1.SubItems[Column].Text.Trim() != "")
                    {
                        fl1 = float.Parse(l1.SubItems[Column].Text);
                    }
                    else
                    {
                        fl1 = defaultvalue;
                    }
                }
                catch { }
                try
                {
                    if (l2.SubItems[Column].Text.Trim() != "")
                    {
                        fl2 = float.Parse(l2.SubItems[Column].Text);
                    }
                    else
                    {
                        fl2 = defaultvalue;
                    }
                }
                catch { }
                if (Order == SortOrder.Ascending)
                { return fl1.CompareTo(fl2); }
                else
                { return fl2.CompareTo(fl1); }
            }
            else if (l1.ListView.Columns[Column].Tag.ToString() == "ddMMyyyy")
            {
                DateTime d1 = new DateTime();
                DateTime d2 = new DateTime();
                try
                {
                    if (l1.SubItems[Column].Text.Trim() != "")
                    {

                        DateTime dAux = DateTime.ParseExact(l1.SubItems[Column].Text, "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
                        d1 = dAux;
                    }
                }
                catch
                { }
                try
                {
                    if (l2.SubItems[Column].Text.Trim() != "")
                    {
                        DateTime dAux = DateTime.ParseExact(l2.SubItems[Column].Text, "dd/MM/yyyy",
                                           System.Globalization.CultureInfo.InvariantCulture);
                        d2 = dAux;
                    }
                }
                catch
                { }
                if (Order == SortOrder.Ascending)
                { return d1.CompareTo(d2); }
                else
                { return d2.CompareTo(d1); }
            }
            else if (l1.ListView.Columns[Column].Tag.ToString() == "ddMMyyyyHHmss" ||
                     l1.ListView.Columns[Column].Tag.ToString() == "ddMMyyyyHHmm" ||
                     l1.ListView.Columns[Column].Tag.ToString() == "ddMyyyyHHm")
            {
                string format = l1.ListView.Columns[Column].Tag.ToString() == "ddMMyyyyHHmss" ? "dd/MM/yyyy HH:m:ss" : "dd/M/yyyy HH:m";

                if (l1.ListView.Columns[Column].Tag.ToString() == "ddMMyyyyHHmm")
                {
                    format = "dd/MM/yyyy HH:mm";
                }

                DateTime d1 = new DateTime();
                DateTime d2 = new DateTime();
                
                try
                {
                    if (l1.SubItems[Column].Text.Trim() != "")
                    {
                        DateTime dAux = DateTime.ParseExact(l1.SubItems[Column].Text, format,
                                           System.Globalization.CultureInfo.InvariantCulture);
                        d1 = dAux;
                    }
                }
                catch
                { }
                try
                {
                    if (l2.SubItems[Column].Text.Trim() != "")
                    {
                        DateTime dAux = DateTime.ParseExact(l2.SubItems[Column].Text, format,
                                           System.Globalization.CultureInfo.InvariantCulture);
                        d2 = dAux;
                    }
                }
                catch
                { }
                if (Order == SortOrder.Ascending)
                { return d1.CompareTo(d2); }
                else
                { return d2.CompareTo(d1); }
            }
            else
            {
                string str1 = l1.SubItems[Column].Text.ToUpper();
                string str2 = l2.SubItems[Column].Text.ToUpper();
                if (Order == SortOrder.Ascending)
                { return str1.CompareTo(str2); }
                else
                { return str2.CompareTo(str1); }
            }
        }
    }
}
