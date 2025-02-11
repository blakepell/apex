﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Apex.Behaviours
{
    /// <summary>
    /// Automatically creates a context menu for a list view item allowing the grid columns to be
    /// shown or hidden.
    /// </summary>
    public class GridViewContextMenuBehaviour : Behavior<ListView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            //  Get the list view.
            //  Ensure we have a grid view.
            if (!(this.AssociatedObject is ListView element) || element.View == null ||
                element.View is GridView == false)
            {
                throw new InvalidOperationException(
                    "The GridViewContextMenuBehaviour must be attached to a ListView with the GridView View.");
            }

            //  Store the gridview.
            gridView = ((GridView)element.View);

            //  Create a context menu.
            var contextMenu = new ContextMenu();

            //  Go through the columns.
            foreach (var column in ((GridView)element.View).Columns)
            {
                //  Create the menu item.
                var menuItem = new MenuItem()
                {
                    Header = column.Header,
                    IsCheckable = true,
                    IsChecked = true
                };

                var theColumn = column;

                //  Create the clicked item.
                menuItem.Click += (sender, e) =>
                {
                    //  If the column exists, remove it.
                    if (gridView.Columns.Contains(theColumn))
                    {
                        removedColumns.Add(Tuple.Create(gridView.Columns.IndexOf(theColumn), theColumn));
                        gridView.Columns.Remove(theColumn);
                        menuItem.IsChecked = false;
                    }
                    else
                    {
                        var theTuple = (from t in removedColumns where t.Item2 == theColumn select t).First();
                        removedColumns.Remove(theTuple);
                        int pos = theTuple.Item1;
                        if (pos > gridView.Columns.Count)
                        {
                            pos = gridView.Columns.Count;
                        }

                        gridView.Columns.Insert(pos, theTuple.Item2);
                    }
                };

                contextMenu.Items.Add(menuItem);
            }

            gridView.ColumnHeaderContextMenu = contextMenu;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        private GridView gridView;

        private List<Tuple<int, GridViewColumn>> removedColumns = new List<Tuple<int, GridViewColumn>>();
    }
}