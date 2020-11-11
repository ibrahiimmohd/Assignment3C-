﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Assignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<string> firstComboList = new List<string>();
        List<string> secondComboList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            firstComboBox.ItemsSource = Fruit.GetItems();
            secondComboBox.ItemsSource = Planet.GetItems();
        }

        private void FirstComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = firstComboBox.SelectedItem as string;

            if (firstComboBox.SelectedIndex != 0)
            {
               
                firstComboList.Add(value);
                firstDataGrid.ItemsSource = firstComboList;
                firstDataGrid.Items.Refresh();
            }
        }

        private void SecondComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = secondComboBox.SelectedItem as string;

            if (secondComboBox.SelectedIndex != 0)
            {
                secondComboList.Add(value);
                secondDataGrid.ItemsSource = secondComboList;
                secondDataGrid.Items.Refresh();
            }
        }

        //I did the logic where when you select an item on the datagrid, it would unselect the "same" item on the other datagrid
        //The issue is there are no similarities at the moment, will need to clarify this later
        private void FirstDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = firstDataGrid.SelectedItem as string;

            if (value != null)
            {
                int index = secondComboList.IndexOf(secondComboList.Find(item => item.Contains(value)));
                if (index != -1)
                {
                    secondComboList.RemoveAt(index);
                }

                secondDataGrid.ItemsSource = secondComboList;
                secondDataGrid.Items.Refresh();
            }
        }

        //I did the logic where when you select an item on the datagrid, it would unselect the "same" item on the other datagrid
        //The issue is there are no similarities at the moment, will need to clarify this later
        private void SecondDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = secondDataGrid.SelectedItem as string;

            if (value != null)
            {
                int index = firstComboList.IndexOf(firstComboList.Find(item => item.Contains(value)));
                if (index != -1)
                {
                    firstComboList.RemoveAt(index);
                }
               
                firstDataGrid.ItemsSource = firstComboList;
                firstDataGrid.Items.Refresh();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstDataGrid.ItemsSource != null || secondDataGrid.ItemsSource != null || thirdDataGrid.ItemsSource != null)
            {
                firstComboList.Clear();
                firstDataGrid.ItemsSource = firstComboList;
                firstDataGrid.Items.Refresh();
                firstComboBox.SelectedIndex = 0;

                secondDataGrid.ItemsSource = secondComboList;
                secondComboList.Clear();
                secondDataGrid.Items.Refresh();
                secondComboBox.SelectedIndex = 0;

                thirdDataGrid.ItemsSource = null;
                thirdDataGrid.Items.Refresh();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstDataGrid.ItemsSource != null || secondDataGrid.ItemsSource != null)
            {
                string valueFirstDatagrid = firstDataGrid.SelectedItem as string;
                string valueSecondDatagrid = secondDataGrid.SelectedItem as string;

                int index;

                if (valueFirstDatagrid != null)
                {
                    index = firstComboList.IndexOf(firstComboList.Find(item => item.Contains(valueFirstDatagrid)));
                    if (index != -1)
                    {
                        firstComboList.RemoveAt(index);
                    }
                    firstDataGrid.ItemsSource = firstComboList;
                    firstDataGrid.Items.Refresh();
                    firstComboBox.SelectedIndex = 0;
                }

                if (valueSecondDatagrid != null)
                {
                    index = secondComboList.IndexOf(secondComboList.Find(item => item.Contains(valueSecondDatagrid)));
                    if (index != -1)
                    {
                        secondComboList.RemoveAt(index);
                    }
                    secondDataGrid.ItemsSource = secondComboList;
                    secondDataGrid.Items.Refresh();
                    secondComboBox.SelectedIndex = 0;
                }
            }
        }
    }
}